using MediatorConstrainedOpenGenericsSample.Models;
using MediatR;
using System;

namespace MediatorConstrainedOpenGenericsSample.Events
{
    public class SomethingDoneEvent : INotification
    {
        public SomethingDoneEvent(Something something)
        {
            Something = something ?? throw new ArgumentNullException(nameof(something));
        }

        public Something Something { get; }
    }
}
