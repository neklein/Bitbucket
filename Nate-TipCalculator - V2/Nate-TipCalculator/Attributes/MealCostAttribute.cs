using Nate_TipCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Attributes
{
    public class MealCostAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is Tip checkTip)
            {
                if (checkTip.MealCost <= 0) return false;
                else return true;
            }
            return false;
        }

    }
}