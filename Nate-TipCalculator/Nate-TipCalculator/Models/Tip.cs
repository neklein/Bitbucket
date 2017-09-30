using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Models
{
    public class Tip
    {
        [DisplayName("Meal Type")]
        public string MealType { get; set; }
        [DisplayName("Meal Cost")]
        public decimal MealCost { get; set; }
        //percentage is the form of a decimal
        [DisplayName("Tip Percentage")]
        public decimal TipPercentage { get; set; }
        public decimal TipTotalForMeal { get; set; }
    }
}