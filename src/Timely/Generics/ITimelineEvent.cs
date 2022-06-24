using Timely.Primitives;

namespace Timely.Generics
{
    public interface ITimelineEvent<T> : ITimelineEvent where T : struct
    {
        T TimePosition { get; }
    }
}
