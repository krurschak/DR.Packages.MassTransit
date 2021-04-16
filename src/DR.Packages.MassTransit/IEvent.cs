using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DR.Packages.MassTransit
{
    public interface IEvent
        : CorrelatedBy<Guid>
    {
    }
}
