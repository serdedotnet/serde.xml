
namespace Serde.Test;

partial class SampleTest
{
    partial record OrderedItem : Serde.ISerializeProvider<Serde.Test.SampleTest.OrderedItem>
    {
        static global::Serde.ISerialize<Serde.Test.SampleTest.OrderedItem> global::Serde.ISerializeProvider<Serde.Test.SampleTest.OrderedItem>.Instance { get; }
            = new Serde.Test.SampleTest.OrderedItem._SerObj();
    }
}
