
namespace Serde.Test;

partial class SampleTest
{
    partial record Address : Serde.ISerializeProvider<Serde.Test.SampleTest.Address>
    {
        static global::Serde.ISerialize<Serde.Test.SampleTest.Address> global::Serde.ISerializeProvider<Serde.Test.SampleTest.Address>.Instance { get; }
            = new Serde.Test.SampleTest.Address._SerObj();
    }
}
