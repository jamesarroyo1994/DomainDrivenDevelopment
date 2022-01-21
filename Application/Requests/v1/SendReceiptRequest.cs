using MediatR;

namespace Application.Requests.v1
{
    public class SendReceiptRequest : IRequest<bool>
    {
        public SendReceiptRequest() {}

        public SendReceiptRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}
