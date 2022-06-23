using System;

namespace Timely.Primitives
{
    public interface ITimelineEvent
    {
        string Name { get; }

        DateTime Date { get; }
    }

}
