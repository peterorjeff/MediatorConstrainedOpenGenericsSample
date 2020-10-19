using MediatR;

namespace MediatorConstrainedOpenGenericsSample.Events
{
    public class IntegrationEvent : INotification
    {
        public string Event { get; set; }
        public object Model { get; set; }
    }

    // Handler for this not compatible with DI in .Net Core 3.x, will be in .Net 5
    public class IntegrationEvent<T> : INotification
    {
        public string Event { get; set; }
        public T Model { get; set; }
    }
}
