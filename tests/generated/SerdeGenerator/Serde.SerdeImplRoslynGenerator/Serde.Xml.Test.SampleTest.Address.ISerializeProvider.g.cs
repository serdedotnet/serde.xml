
namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record Address : Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.Address>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.SampleTest.Address> global::Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.Address>.Instance { get; }
            = new Serde.Xml.Test.SampleTest.Address._SerObj();
    }
}
