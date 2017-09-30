using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulePrototype.Models
{
    public class TractorClassRepository
    {
        public static List<TractorClass> GetAll()
        {
            return new List<TractorClass>
            {
                new TractorClass{TClassID = 1, TClassName = "10,000 Hot Farm"},
                new TractorClass{TClassID = 2, TClassName = "Hot Rod Tractor"},
                new TractorClass{TClassID = 3, TClassName = "Super Modified 4x4"},
                new TractorClass{TClassID = 4, TClassName = "8500 Farm Stock"}
            };
        }
    }
}