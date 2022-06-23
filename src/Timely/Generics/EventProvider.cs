using System;
using System.Collections.Generic;
using Timely.Primitives;

namespace Timely.Generics
{
    public static class EventProvider<TSource, TEvent>
        where TSource : class
        where TEvent : ITimelineEvent
    {
        public static IEnumerable<TEvent> ProvideEvents(IEnumerable<TSource> source, Func<TSource, TEvent> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }
    }
}
