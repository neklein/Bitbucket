using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Course: IValidatableObject
    {
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(CourseName))
            {
                errors.Add(new ValidationResult("Please enter the name of the course you wish to add", 
                    new[] { "CourseName" }));
            }

            return errors;
        }
    }
}