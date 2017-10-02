using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());


            if (ModelState.IsValid)
            {
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                return View("Add", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = StudentRepository.Get(id);

            StudentVM viewModel = new StudentVM();
            viewModel.Student = model;
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());

            if (ModelState.IsValid)
            {
                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Edit(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                return RedirectToAction("List");
            }
            else
            {
                return View("Edit", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = StudentRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}