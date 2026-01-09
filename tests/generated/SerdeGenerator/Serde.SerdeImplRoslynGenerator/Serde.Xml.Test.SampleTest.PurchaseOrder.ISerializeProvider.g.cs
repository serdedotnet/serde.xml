
namespace Serde.Xml.Test;

partial class SampleTest
{
    partial record PurchaseOrder : Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.PurchaseOrder>
    {
        static global::Serde.ISerialize<Serde.Xml.Test.SampleTest.PurchaseOrder> global::Serde.ISerializeProvider<Serde.Xml.Test.SampleTest.PurchaseOrder>.Instance { get; }
            = new Serde.Xml.Test.SampleTest.PurchaseOrder._SerObj();
    }
}
