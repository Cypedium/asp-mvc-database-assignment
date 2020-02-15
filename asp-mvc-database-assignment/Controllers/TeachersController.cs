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
    public class TeachersController : Controller
    {
        //---Init and Index-----------------------------------------------------------
        ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public IActionResult Index()
        {
            return View(_teacherService.All());
        }
        //-----------------------------------------------------------------------------

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.Create(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Teacher teacherDetails = _teacherService.Find(id);
            if (teacherDetails == null)
            {
                return RedirectToAction("Index");
            }
            return View(teacherDetails);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _teacherService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Teacher aTeacher = _teacherService.Find(id);
            if (aTeacher == null)
            {
                return RedirectToAction("Index");
            }
            return View(aTeacher);
        }

        [HttpPost]
        public IActionResult Remove(Teacher teacher)
        {
            bool result = _teacherService.Remove(teacher.Id);

            if (result)
            {
                ViewBag.msg = "Your Student has been succesfully removed";
            }
            else
            {
                ViewBag.msg = "Unable to remove Student";
            }

            return View("Index", _teacherService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Teacher teacher = _teacherService.Find(id);
            if (teacher == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_teacherService.All());
            }
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.Update(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
    }
}