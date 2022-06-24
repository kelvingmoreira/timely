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
        private OffsetType _offsetType;
        private DateTime _relatedDate;

        public RelativeEvent(OffsetType offsetType, DateTime date)
        {
            _offsetType = offsetType;
            _relatedDate = date;
            _name = $"Event on {Date}";
        }

        private string _name;

        public string Name { get => _name; set => _name = value; }

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
    }

    public enum OffsetType
    {
        Days = 0,
        Months,
        Years
    }
}
