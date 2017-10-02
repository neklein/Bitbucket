using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class State:IValidatableObject
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(StateAbbreviation))
            {
                errors.Add(new ValidationResult("Please enter the abbreviation for the state",
                    new[] { "StateAbbreviation" }));
            }
            if (string.IsNullOrWhiteSpace(StateName))
            {
                errors.Add(new ValidationResult("Please enter the state name",
                    new[] { "StateName" }));
            }

            return errors;
        }
    }
}