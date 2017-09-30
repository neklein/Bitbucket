using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppointmentSetupApp.Attributes
{
    public class NoWeekendsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime checkDate = (DateTime)value;

            if(value is DateTime)
            {
                if (checkDate.DayOfWeek == DayOfWeek.Saturday
                    || checkDate.DayOfWeek == DayOfWeek.Sunday)
                    return false;
                else
                    return true;

            }
            return false;
        }
    }
}