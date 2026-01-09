using System;
using System.Text;

namespace Serde.Xml;

/// <summary>
/// A hand-written recursive descent parser for C# reflection type names.
/// Parses grammar:
///   fullType      : typeName generics? ;
///   typeName      : qualifiedName arrayBrackets* ;
///   qualifiedName : (IDENT '.')* IDENT ;
///   generics      : '`' NUM+ '[' fullType ']' ;
///   arrayBrackets : '[' ']' ;
///   IDENT         : [_a-zA-Z]+ NUM* ;
///   NUM           : [0-9]+ ;
/// </summary>
internal static class ReflectionTypeNameParser
{
    /// <summary>
    /// Represents a parsed reflection type name.
    /// </summary>
    internal sealed record ParsedTypeName(
        string SimpleName,
        int ArrayRank,
        ParsedTypeName? GenericArgument);

    /// <summary>
    /// Parses a reflection type name string into a <see cref="ParsedTypeName"/>.
    /// </summary>
    /// <param name="input">The type name string to parse.</param>
    /// <returns>The parsed type name.</returns>
    /// <exception cref="FormatException">Thrown if the input is not a valid type name.</exception>
    internal static ParsedTypeName Parse(string input)
    {
        var parser = new Parser(input);
        var result = parser.ParseFullType();
        if (!parser.IsAtEnd)
        {
            throw new FormatException($"Unexpected character at position {parser.Position}: '{parser.Current}'");
        }
        return result;
    }

    /// <summary>
    /// Formats a reflection type name into an XML-friendly element name.
    /// For example: "System.Int32[]" becomes "ArrayOfInt".
    /// </summary>
    internal static string FormatForXml(string input)
    {
        var parsed = Parse(input);
        return FormatParsedType(parsed);
    }

    private static string FormatParsedType(ParsedTypeName parsed)
    {
        var sb = new StringBuilder();

        // Add "ArrayOf" prefix for each array dimension
        for (int i = 0; i < parsed.ArrayRank; i++)
        {
            sb.Append("ArrayOf");
        }

        // Map certain type names to XML-friendly versions
        var name = parsed.SimpleName switch
        {
            "Int32" => "Int",
            "UInt32" => "UnsignedInt",
            _ => parsed.SimpleName
        };
        sb.Append(name);

        // Handle generic type arguments
        if (parsed.GenericArgument is not null)
        {
            sb.Append("Of");
            sb.Append(FormatParsedType(parsed.GenericArgument));
        }

        return sb.ToString();
    }

    private ref struct Parser
    {
        private readonly ReadOnlySpan<char> _input;
        private int _position;

        public Parser(string input)
        {
            _input = input.AsSpan();
            _position = 0;
        }

        public int Position => _position;
        public bool IsAtEnd => _position >= _input.Length;
        public char Current => IsAtEnd ? '\0' : _input[_position];

        /// <summary>
        /// fullType : typeName generics? ;
        /// </summary>
        public ParsedTypeName ParseFullType()
        {
            var (simpleName, arrayRank) = ParseTypeName();
            ParsedTypeName? genericArg = null;

            if (!IsAtEnd && Current == '`')
            {
                genericArg = ParseGenerics();
            }

            return new ParsedTypeName(simpleName, arrayRank, genericArg);
        }

        /// <summary>
        /// typeName : qualifiedName arrayBrackets* ;
        /// Returns (simpleName, arrayRank)
        /// </summary>
        private (string SimpleName, int ArrayRank) ParseTypeName()
        {
            var qualifiedName = ParseQualifiedName();
            int arrayRank = 0;

            while (!IsAtEnd && Current == '[' && Peek(1) == ']')
            {
                Advance(); // skip '['
                Advance(); // skip ']'
                arrayRank++;
            }

            // Extract just the simple name (last part after the last dot)
            int lastDot = qualifiedName.LastIndexOf('.');
            string simpleName = lastDot >= 0 ? qualifiedName.Substring(lastDot + 1) : qualifiedName;

            return (simpleName, arrayRank);
        }

        /// <summary>
        /// qualifiedName : (IDENT '.')* IDENT ;
        /// </summary>
        private string ParseQualifiedName()
        {
            var sb = new StringBuilder();

            while (true)
            {
                string ident = ParseIdent();
                sb.Append(ident);

                if (!IsAtEnd && Current == '.')
                {
                    sb.Append('.');
                    Advance(); // skip '.'
                }
                else
                {
                    break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// generics : '`' NUM+ '[' fullType ']' ;
        /// </summary>
        private ParsedTypeName ParseGenerics()
        {
            Expect('`');

            // Skip the arity number (e.g., "1" in List`1)
            while (!IsAtEnd && char.IsDigit(Current))
            {
                Advance();
            }

            Expect('[');
            var innerType = ParseFullType();
            Expect(']');

            return innerType;
        }

        /// <summary>
        /// IDENT : [_a-zA-Z]+ NUM* ;
        /// </summary>
        private string ParseIdent()
        {
            int start = _position;

            // First part: letters and underscores
            while (!IsAtEnd && (char.IsLetter(Current) || Current == '_'))
            {
                Advance();
            }

            // Second part: digits
            while (!IsAtEnd && char.IsDigit(Current))
            {
                Advance();
            }

            if (_position == start)
            {
                throw new FormatException($"Expected identifier at position {_position}");
            }

            return _input.Slice(start, _position - start).ToString();
        }

        private char Peek(int offset)
        {
            int pos = _position + offset;
            return pos >= _input.Length ? '\0' : _input[pos];
        }

        private void Advance()
        {
            if (!IsAtEnd)
            {
                _position++;
            }
        }

        private void Expect(char expected)
        {
            if (IsAtEnd || Current != expected)
            {
                throw new FormatException($"Expected '{expected}' at position {_position}, got '{(IsAtEnd ? "EOF" : Current.ToString())}'");
            }
            Advance();
        }
    }
}
