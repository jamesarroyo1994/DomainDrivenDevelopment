using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Requests.v1;
using Domain.Entities.Receipts.Messages;
using Infrastructure.EventPublisher;
using MediatR;

namespace Application.Requests.v1
{
    public class SendReceiptRequestHandler : IRequestHandler<SendReceiptRequest, bool>
    {
        private readonly IEventPublisher _eventPublisher;

        public SendReceiptRequestHandler(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public async Task<bool> Handle(SendReceiptRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _eventPublisher.Publish(new SendReceiptMessage
                {
                    OrderId = request.OrderId
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
