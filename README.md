# Serde Custom Format Template

A template repository for creating custom Serde format serializers/deserializers for .NET using [Serde](https://github.com/serdedotnet/serde).

## Status

This is a template repository. The structure is set up but implementation is not yet started. To use this template:

1. Fork or use this repository as a template
2. Rename `Serde.CustomFormat` to your format name (e.g., `Serde.YourFormat`)
3. Update the solution and project files accordingly
4. Implement your custom format serializer/deserializer

## Building

```bash
dotnet build
```

## Testing

```bash
dotnet test
```

## Benchmarking

```bash
dotnet run --project bench -c Release
```

## License

BSD 3-Clause License. See [LICENSE](LICENSE) for details.
