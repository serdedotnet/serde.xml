
namespace Serde.Test;

partial class XmlTests
{
    partial record StructWithIntField : Serde.ISerializeProvider<Serde.Test.XmlTests.StructWithIntField>
    {
        static global::Serde.ISerialize<Serde.Test.XmlTests.StructWithIntField> global::Serde.ISerializeProvider<Serde.Test.XmlTests.StructWithIntField>.Instance { get; }
            = new Serde.Test.XmlTests.StructWithIntField._SerObj();
    }
}
