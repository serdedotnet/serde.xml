
namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record OrderedItem : Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.OrderedItem>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.SampleTest.OrderedItem> global::Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.OrderedItem>.Instance { get; }
            = new Serde.Xml.Test.SampleTest.OrderedItem._SerObj();
    }
}
