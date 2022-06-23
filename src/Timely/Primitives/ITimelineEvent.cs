using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timely.Primitives
{
    public interface ITimelineEvent
    {
        string Name { get; }

        DateTime Date { get; }
    }

}
