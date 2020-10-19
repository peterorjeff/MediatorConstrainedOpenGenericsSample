using MediatorConstrainedOpenGenericsSample.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorConstrainedOpenGenericsSample.Commands
{
    public class DoSomethingCommandHandler : IRequestHandler<DoSomethingCommand, Something>
    {
        public async Task<Something> Handle(DoSomethingCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(500);

            Console.WriteLine("Handled DoSomethingCommand");

            return new Something();
        }
    }
}
