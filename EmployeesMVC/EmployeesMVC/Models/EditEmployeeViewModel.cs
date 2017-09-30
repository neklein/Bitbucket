using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesMVC.Models
{
    public class EditEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please Enter the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter the last name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public List<SelectListItem> Departments { get; set; }

    }
}