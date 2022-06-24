using System;
using System.Collections.Generic;
using System.Linq;
using Timely.Primitives;

namespace Timely.Generics
{
    public static class EventProvider
    {
        public static IEnumerable<TEvent> ProvideEvent<TSource, TEvent>(IEnumerable<TSource> source, Func<TSource, TEvent> selector)
            where TSource : class
            where TEvent : ITimelineEvent
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<ITimelineEvent> ProvideMultipleEvents<TSource, TEvents>(IEnumerable<TSource> source, Func<TSource, TEvents> selector)
            where TSource : class
            where TEvents : IList<ITimelineEvent>
        {
            foreach (TSource item in source)
            {
                foreach (ITimelineEvent evt in selector(item))
                {
                    yield return evt;
                }
            }
        }

        public static List<ITimelineEvent> CreateTimeline(params IEnumerable<ITimelineEvent>[] events)
        {
            return Flatten(events).OrderBy(t => t.Date).ToList();
        }

        private static IEnumerable<ITimelineEvent> Flatten(params IEnumerable<ITimelineEvent>[] events)
        {
            foreach (IEnumerable<ITimelineEvent> enumerable in events)
            {
                foreach (ITimelineEvent timelineEvent in enumerable)
                {
                    yield return timelineEvent;
                }
            }
        }
    }
}
