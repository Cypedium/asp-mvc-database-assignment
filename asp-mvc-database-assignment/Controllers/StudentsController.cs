using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_mvc_database_assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_mvc_database_assignment.Controllers
{
    public class StudentsController : Controller
    {
        //---Init and Index-----------------------------------------------------------
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View(_studentService.All());
        }
        //-----------------------------------------------------------------------------

        //Create-----------------------------------------------------------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Create(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Student studentDetails = _studentService.Find(id);
            if (studentDetails==null)
            {
                return RedirectToAction("Index");
            }
            return View(studentDetails);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _studentService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Student aStudent = _studentService.Find(id);
            if (aStudent==null)
            {
                return RedirectToAction("Index");
            }
            return View(aStudent);
        }

        [HttpPost]
        public IActionResult Remove(Student student)
        {
            bool result = _studentService.Remove(student.Id);

            if (result)
            {
                ViewBag.msg = "Your Student has been succesfully removed";
            }
            else
            {
                ViewBag.msg = "Unable to remove Student";
            }

            return View( "Index",_studentService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = _studentService.Find(id);
            if (student == null)
            {
                ViewBag.msg = "The Student was not found";
                return View(_studentService.All());
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Update(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}