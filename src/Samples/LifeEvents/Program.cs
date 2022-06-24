using LifeEvents.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.Events;
using Timely.Generics;
using Timely.Primitives;

namespace LifeEvents
{
    public class Program
    {
        public static void Main()
        {
            List<Person> lives = new List<Person>();
            Person me = new Person();

            me.Name = "Kelvin";
            me.Birth = new Birth
            {
                HospitalName = "Hospital of Life",
                Weight = 5.06,
                Height = 54.0,
                DateOfBirth = new DateTime(1996, 03, 08),
            };
            me.Graduation = new Graduation
            {
                CollegeName = "School of Life",
                FieldName = "Living",
                Date = new DateTime(2018, 01, 01),
            };
            me.Death = new Death
            {
                DateOfDeath = new DateTime(2022, 04, 18),
                Obituary = "Farewell World!"
            };

            Person anotherPerson = new Person();

            anotherPerson.Name = "John Doe";
            anotherPerson.Birth = new Birth
            {
                HospitalName = "Hospital of Life",
                Weight = 4.03,
                Height = 47.0,
                DateOfBirth = new DateTime(2000, 02, 29),
            };
            anotherPerson.Graduation = new Graduation
            {
                CollegeName = "School of Life",
                FieldName = "Living",
                Date = new DateTime(2022, 01, 01),
            };
            anotherPerson.Death = new Death
            {
                DateOfDeath = new DateTime(2057, 11, 18),
                Obituary = "Farewell World!"
            };

            lives.Add(me);
            lives.Add(anotherPerson);

            IEnumerable<DiscreteEvent> births = EventProvider.ProvideEvent(lives, l => new DiscreteEvent($"{l.Name} was born", l.Birth.DateOfBirth));
            IEnumerable<DiscreteEvent> graduations = EventProvider.ProvideEvent(lives, l => new DiscreteEvent($"{l.Name} graduated", l.Graduation.Date));
            IEnumerable<DiscreteEvent> deaths = EventProvider.ProvideEvent(lives, l => new DiscreteEvent($"{l.Name} died", l.Death.DateOfDeath));

            IEnumerable<RelativeEvent> comingOfAge = EventProvider.ProvideEvent(lives, l => new RelativeEvent($"{l.Name} became an adult", l.Birth.DateOfBirth, 18, OffsetType.Years));

            foreach (ITimelineEvent timelineEvent in EventProvider.CreateTimeline(births, graduations, deaths, comingOfAge))
            {
                Console.WriteLine(timelineEvent);
            }

            Console.ReadLine();
        }
    }
}
