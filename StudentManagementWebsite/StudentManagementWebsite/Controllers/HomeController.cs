using StudentManagementWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            List<Student> allStudents = StudentRepository.GetStudents();
            return View("AdminIndex", allStudents);
        }

        [HttpGet]
        public ActionResult AddStudent(Student model)
        {
            StudentRepository.SetStudent(model);
            return RedirectToAction("GetStudent", "Home");
        }

        public ActionResult GetStudent()
        {
            Student student = StudentRepository.GetStudent();
            List<Student> list = StudentRepository.GetStudents();

            return View("AdminIndex", "Admin", list);
        }
    }
}