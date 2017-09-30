using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TractorFanSite.Models
{
    public class TractorRepo
    {
        static Tractor _myTractor;

        static TractorRepo()
        {
            _myTractor = new Tractor()
            {
                Name = "Big Chief",
                TractorClass = "Hot Rod Tractor",
                Driver = "Jeff",
                TractorImage = "Finish",

            };
        }

        public static Tractor GetTractor()
        {
            return _myTractor;
        }

        public static void SetTractor(Tractor newTractor)
        {
            _myTractor = newTractor;
        }
    }
}