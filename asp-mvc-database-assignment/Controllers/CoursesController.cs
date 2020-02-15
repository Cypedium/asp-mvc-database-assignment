using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp_mvc_database_assignment.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        //---Init and Index-----------------------------------------------------------
        ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View(_courseService.All());
        }
        //-----------------------------------------------------------------------------

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                _courseService.Create(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Course courseDetails = _courseService.Find(id);
            if (courseDetails == null)
            {
                return RedirectToAction("Index");
            }
            return View(courseDetails);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _courseService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Course aCourse = _courseService.Find(id);
            if (aCourse == null)
            {
                return RedirectToAction("Index");
            }
            return View(aCourse);
        }

        [HttpPost]
        public IActionResult Remove(Course course)
        {
            bool result = _courseService.Remove(course.Id);

            if (result)
            {
                ViewBag.msg = "Your Student has been succesfully removed";
            }
            else
            {
                ViewBag.msg = "Unable to remove Student";
            }

            return View("Index", _courseService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course course = _courseService.Find(id);
            if (course == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_courseService.All());
            }
            return View(course);
        }
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }
    }
}
