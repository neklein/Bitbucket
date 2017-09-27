using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeVisit.Models
{
    public class VisitRequest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool WantsDormitoryVisit { get; set; }
        public List<SelectListItem> Majors { get; set; }
        public string SelectedMajor { get; set; }
    }
}