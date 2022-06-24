using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Generics;
using Timely.Primitives;

namespace Timely.Events
{

    public class DiscreteEvent : ITimelineEvent<DateTime>
    {
        public DiscreteEvent( DateTime eventDate)
        {
            Name = "Event";
            TimePosition = eventDate;
        }

        public DiscreteEvent(string name, DateTime eventDate)
        {
            Name = name;
            TimePosition = eventDate;
        }

        public string Name { get; set; }

        public DateTime TimePosition { get; set; }

        public DateTime Date => TimePosition;


        public override string ToString()
        {
            return $"{Name} on {Date}";
        }
    }
}
