using MediatorConstrainedOpenGenericsSample.Events;
using MediatorConstrainedOpenGenericsSample.Interfaces;
using MediatorConstrainedOpenGenericsSample.Models;
using MediatR;

namespace MediatorConstrainedOpenGenericsSample.Commands
{
    public class DoSomethingCommand : IRequest<Something>, IDomainEvent<SomethingDoneEvent>
    {
    }
}
