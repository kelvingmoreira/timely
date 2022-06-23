using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Primitives;

namespace Timely.Generics
{
    public static class MultiEventProvider<TSource, TEvents>
        where TSource : class
        where TEvents : IList<ITimelineEvent>
    {
        public static IEnumerable<ITimelineEvent> ProvideEvents(IEnumerable<TSource> source, Func<TSource, TEvents> selector)
        {
            foreach (TSource item in source)
            {
                foreach (ITimelineEvent evt in selector(item))
                {
                    yield return evt;
                }
            }
        }
    }
}
