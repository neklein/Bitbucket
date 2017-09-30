using AppointmentSetupApp.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppointmentSetupApp.Models
{
    [NoGarfieldMondays(ErrorMessage = "Garfield cannot book appointments on Mondays")]
    public class AppointmentRequest
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string ClientName { get; set; }

        [FutureDate(ErrorMessage = "You must book an appointment in the future")]
        [NoWeekends(ErrorMessage = "You cannot book appointments on the weekend")]
        [Required(ErrorMessage = "Please enter a valid date")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "Please read and accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}