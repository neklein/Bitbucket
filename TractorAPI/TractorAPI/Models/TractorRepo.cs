using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TractorAPI.Models
{
    public class TractorRepo
    {
        private static List<Tractor> _tractors = new List<Tractor>
        {
            new Tractor{TractorID = 1, TractorName = "The Kentuckian", TractorDriver = "Donny", TractorClass = "Super Modified"},
            new Tractor{TractorID = 2, TractorName = "Hillbilly Rocket", TractorDriver = "Melvin", TractorClass = "10,000 Hot Farm"},
            new Tractor{TractorID = 3, TractorName = "Big Chief", TractorDriver = "Jeff", TractorClass = "Hot Rod Tractor"},
            new Tractor{TractorID = 4, TractorName = "Costly Habit", TractorDriver = "Dennis", TractorClass = "10,000 Hot Farm"}
        };

        public static List<Tractor> GetAll()
        {
            return _tractors;
        }

        public static Tractor Get(int tractorID)
        {
            return _tractors.FirstOrDefault(m => m.TractorID == tractorID);
        }

        public static void Add(Tractor tractor)
        {
            tractor.TractorID = _tractors.Max(m => m.TractorID) + 1;
            _tractors.Add(tractor);
        }

        public static void Edit(Tractor tractor)
        {
            var found = _tractors.FirstOrDefault(m => m.TractorID == tractor.TractorID);

            if(found != null)
            {
                found = tractor;
            }
        }

        public static void Delete(int tractorID)
        {
            _tractors.RemoveAll(m => m.TractorID == tractorID);
        }
    }
}