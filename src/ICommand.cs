using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Packages.MassTransit
{
    interface ICommand : IMessage
    {
        Guid OperationId { get; }
    }
}
