using Domain.Base;

namespace Domain.Entities.Receipts.Messages
{
    public class SendReceiptMessage : BaseMessage
    {
        public int OrderId { get; set; }
    }
}
