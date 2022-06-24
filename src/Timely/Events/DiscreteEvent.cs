using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Generics;

namespace Timely.Events
{

    public class DiscreteEvent : ITimelineEvent<DateTime>
    {
        public DiscreteEvent(DateTime eventDate)
        {
            TimePosition = eventDate;
        }

        public string Name => $"Event on {TimePosition}";

        public DateTime TimePosition { get; set; }

        public DateTime Date => TimePosition;
    }
}
