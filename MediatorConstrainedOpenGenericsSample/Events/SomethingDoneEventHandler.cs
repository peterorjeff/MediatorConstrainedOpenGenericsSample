using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorConstrainedOpenGenericsSample.Events
{
    public class SomethingDoneEventHandler : INotificationHandler<SomethingDoneEvent>
    {
        private readonly IPublisher _publisher;

        public SomethingDoneEventHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(SomethingDoneEvent notification, CancellationToken cancellationToken)
        {
            await _publisher.Publish(
                new IntegrationEvent
                {
                    Event = nameof(SomethingDoneEvent),
                    Model = notification.Something
                },
                cancellationToken
            );

            Console.WriteLine($"Handled SomethingDoneEvent {notification.Something.SomeString}");
        }
    }
}
