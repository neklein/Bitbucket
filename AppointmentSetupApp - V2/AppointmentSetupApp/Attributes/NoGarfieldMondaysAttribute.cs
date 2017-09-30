using AppointmentSetupApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppointmentSetupApp.Attributes
{
    public class NoGarfieldMondaysAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is AppointmentRequest model)
            {
                if(!string.IsNullOrWhiteSpace(model.ClientName)
                    && model.ClientName.ToLower() == "garfield")
                {
                    if (model.Date.DayOfWeek == DayOfWeek.Monday)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}