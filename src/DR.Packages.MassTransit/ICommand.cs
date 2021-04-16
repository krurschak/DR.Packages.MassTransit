using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Packages.MassTransit
{
    public interface ICommand : IEvent
    {
        Guid CommandId { get; }
    }
}
