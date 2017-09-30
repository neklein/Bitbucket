using Nate_TipCalculator.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Models
{
    [TipValidationAttribute(ErrorMessage = "That is one miserly tip!")]
    [MealCostAttribute(ErrorMessage = "Please enter a positive value for the cost of the meal")]
    public class Tip
    {
        [DisplayName("Meal Type")]
        [Required(ErrorMessage = "Please provide the type of meal")]
        public string MealType { get; set; }
        [DisplayName("Meal Cost")]
        [Required(ErrorMessage = "Please provide the cost of the meal")]
        public decimal? MealCost { get; set; }
        //percentage is the form of a decimal
        [DisplayName("Tip Percentage")]
        [Required(ErrorMessage = "Please provide the percentage of the tip")]
        public decimal? TipPercentage { get; set; }
        public decimal? TipTotalForMeal { get; set; }
    }
}