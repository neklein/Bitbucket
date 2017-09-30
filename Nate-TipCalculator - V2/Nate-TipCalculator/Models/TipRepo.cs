using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Models
{
    public class TipRepo
    {
        static Tip _myTip;

        public static Tip GetTip()
        {
            return _myTip;
        }

        public static void SetTip(Tip newTip)
        {
            _myTip = newTip;
        }
    }
}