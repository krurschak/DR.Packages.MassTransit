using System;
using System.Collections.Generic;
using System.Text;
using MassTransit;

namespace DR.Packages.MassTransit
{
    public interface IMessage
        : CorrelatedBy<Guid>
    {
    }
}
