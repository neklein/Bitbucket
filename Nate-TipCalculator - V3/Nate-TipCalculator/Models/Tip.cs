using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Models
{
    public class Tip : IValidatableObject
    {
        [DisplayName("Meal Type")]
        public string MealType { get; set; }
        [DisplayName("Meal Cost")]
        public decimal? MealCost { get; set; }
        //percentage is the form of a decimal
        [DisplayName("Tip Percentage")]
        public decimal? TipPercentage { get; set; }
        public decimal? TipTotalForMeal { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(MealType))
            {
                errors.Add(new ValidationResult("Please enter the meal type",
                    new[] { "MealType" }));
            }
            if (MealCost == null || MealCost <= 0)
            {
                errors.Add(new ValidationResult("Please enter the cost of the meal",
                    new[] { "MealCost" }));
            }
            if (TipPercentage == null || TipPercentage <= 0)
            {
                errors.Add(new ValidationResult("Please enter a positive tip amount",
                    new[] { "TipPercentage" }));
            }

            return errors;
        }
    }
}