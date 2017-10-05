using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrWhiteSpace(major.MajorName))
            {
                ModelState.AddModelError("MajorName", "Please enter a name for the Major");
                return View("AddMajor", major);
            }
            else
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrWhiteSpace(major.MajorName))
            {
                ModelState.AddModelError("MajorName", "Please enter a name for the Major");
                return View("EditMajor", major);
            }

            else
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");

            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }
        
        [HttpGet]
        public ActionResult GetStates()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());

        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            if (string.IsNullOrWhiteSpace(state.StateName))
            {
                ModelState.AddModelError("StateName", "Please enter the name of the state");
                return View("AddState", state);

            }
            else if (string.IsNullOrWhiteSpace(state.StateAbbreviation))
            {
                ModelState.AddModelError("StateAbbreviation", "Please enter the state abbreviation");
                return View("AddState", state);

            }
            else
            {
                StateRepository.Add(state);
                return RedirectToAction("GetStates");

            }
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrWhiteSpace(state.StateName))
            {
                ModelState.AddModelError("StateName", "Please enter the name of the state");
                return View("EditState", state);

            }
            else if (string.IsNullOrWhiteSpace(state.StateAbbreviation))
            {
                ModelState.AddModelError("StateAbbreviation", "Please enter the state abbreviation");
                return View("EditState", state);

            }

            else
            {
                StateRepository.Edit(state);
                return RedirectToAction("GetStates");
            }
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("GetStates");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();

            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");

            }
            else
            {
                return View("AddCourse", course);
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                return View("EditCourse", course);
            }
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}