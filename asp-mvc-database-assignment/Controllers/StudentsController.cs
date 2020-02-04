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
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View(_studentService.All());
        }
        //---Init and Index-----------------------------------------------------------

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
    }
}