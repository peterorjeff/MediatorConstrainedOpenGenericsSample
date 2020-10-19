using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorConstrainedOpenGenericsSample.Events
{
    public class IntegrationEventHandler : INotificationHandler<IntegrationEvent>
    {
        public async Task Handle(IntegrationEvent notification, CancellationToken cancellationToken)
        {
            await Task.Delay(500);

            var json = JsonConvert.SerializeObject(notification);
            Console.WriteLine($"Handled IntegrationEvent {json}");
        }
    }

    // This is not compatible with DI in .Net Core 3.x, will be in .Net 5
    //public class IntegrationEventHandler<T> : INotificationHandler<IntegrationEvent<T>>
    //{
    //    public async Task Handle(IntegrationEvent<T> notification, CancellationToken cancellationToken)
    //    {
    //        await Task.Delay(500);

    //        var json = JsonConvert.SerializeObject(notification);
    //        Console.WriteLine($"Handled IntegrationEvent {json}");
    //    }
    //}
}
