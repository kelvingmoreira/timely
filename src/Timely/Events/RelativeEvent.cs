using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Generics;

namespace Timely.Events
{
    public class RelativeEvent : ITimelineEvent<int>
    {
        private readonly OffsetType _offsetType;
        private readonly DateTime _relatedDate;

        public RelativeEvent(DateTime date, int offset, OffsetType offsetType)
        {
            TimePosition = offset;
            Name = "Event";

            _offsetType = offsetType;
            _relatedDate = date;
        }

        public RelativeEvent(string name, DateTime date, int offset, OffsetType offsetType )
        {
            TimePosition = offset;
            Name = name;

            _offsetType = offsetType;
            _relatedDate = date;
        }

        public string Name { get; set; }

        public int TimePosition { get; set; }

        public DateTime Date
        {
            get
            {
                return _offsetType switch
                {
                    OffsetType.Days => _relatedDate.AddDays(TimePosition),
                    OffsetType.Months => _relatedDate.AddMonths(TimePosition),
                    OffsetType.Years => _relatedDate.AddYears(TimePosition),
                    _ => _relatedDate,
                };
            }
        }

        public override string ToString()
        {
            return $"{Name} on {Date}";
        }
    }

    public enum OffsetType
    {
        Days = 0,
        Months,
        Years
    }
}
