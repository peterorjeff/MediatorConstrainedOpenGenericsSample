using MediatR;

namespace MediatorConstrainedOpenGenericsSample.Interfaces
{
    public interface IDomainEvent<T> where T : INotification
    {
    }
}
