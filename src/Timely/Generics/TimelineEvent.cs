using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Generics;

namespace Timely.Generics
{
    public abstract class TimelineEvent<T> : ITimelineEvent<T> where T : class
    {
        public virtual string Name => Event.ToString();

        public T Event { get; set; }

        public abstract DateTime Date { get; }
    }
}
