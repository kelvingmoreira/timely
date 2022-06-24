using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeEvents.Common
{
    public class Person
    {
        public string Name { get; set; }

        public Birth Birth { get; set; }

        public Graduation Graduation { get; set; }

        public Death Death { get; set; }
    }
}
