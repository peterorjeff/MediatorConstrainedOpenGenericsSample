using MediatorConstrainedOpenGenericsSample.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorConstrainedOpenGenericsSample.Behaviours
{
    public class DomainEventPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IPublisher _publisher;

        public DomainEventPostProcessor(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            object domainEvent = null;

            try
            {
                // Requests will implement IDomainEvent<T> if they should trigger a Domain Event.
                var interfaceType = request.GetType()
                    .GetInterfaces()
                    .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDomainEvent<>));

                if (interfaceType != null)
                {
                    // The type of Notification we want to publish is the T from IDomainEvent<T>, e.g. GroupCreatedEvent from IDomainEvent<GroupCreatedEvent>.
                    var domainEventType = interfaceType.GetGenericArguments()[0];
                    if (domainEventType != null)
                    {
                        // Create the Domain Event, and pass in the response.
                        // All Domain Events should have a constructor to take in the Model, e.g. GroupDto.
                        domainEvent = Activator.CreateInstance(domainEventType, response);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error determining IDomainEvent: {ex.Message}");
            }

            if (domainEvent != null)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
