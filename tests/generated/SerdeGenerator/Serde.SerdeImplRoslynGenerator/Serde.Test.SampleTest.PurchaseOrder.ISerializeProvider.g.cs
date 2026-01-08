
namespace Serde.Test;

partial class SampleTest
{
    partial record PurchaseOrder : Serde.ISerializeProvider<Serde.Test.SampleTest.PurchaseOrder>
    {
        static global::Serde.ISerialize<Serde.Test.SampleTest.PurchaseOrder> global::Serde.ISerializeProvider<Serde.Test.SampleTest.PurchaseOrder>.Instance { get; }
            = new Serde.Test.SampleTest.PurchaseOrder._SerObj();
    }
}
