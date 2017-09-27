using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nate_TipCalculator.Models
{
    public class Tip
    {
        public string MealType { get; set; }
        public decimal MealCost { get; set; }
        //percentage is the form of a decimal
        public decimal TipPercentage { get; set; }
        public decimal TipTotalForMeal { get; set; }
    }
}