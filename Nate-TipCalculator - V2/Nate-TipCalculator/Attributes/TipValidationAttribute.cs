using Nate_TipCalculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Attributes
{
    public class TipValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is Tip checkTip)
            {
                if (checkTip.TipPercentage <= 10) return false;
                else return true;
            }
            return false;
        }
    }
}