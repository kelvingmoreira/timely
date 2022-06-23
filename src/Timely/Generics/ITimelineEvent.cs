using Timely.Primitives;

namespace Timely.Generics
{
    public interface ITimelineEvent<T> : ITimelineEvent where T : class
    {
        T Event { get; }
    }
}
