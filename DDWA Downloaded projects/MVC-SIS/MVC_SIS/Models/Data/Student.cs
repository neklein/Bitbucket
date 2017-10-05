using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student:IValidatableObject
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                errors.Add(new ValidationResult("Please enter the student's first name",
                    new[] { "FirstName" }));
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                errors.Add(new ValidationResult("Please enter the student's last name",
                    new[] { "LastName" }));
            }
            if(Major.MajorId == 0)
            {
                errors.Add(new ValidationResult("Please select a major",
                    new[] { "MajorId" }));
            }

            return errors;
        }
    }
}