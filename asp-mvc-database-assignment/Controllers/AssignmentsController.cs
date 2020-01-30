using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using asp_mvc_database_assignment.Models;


namespace asp_mvc_database_assignment.Controllers
{
    public class AssignmentsController : Controller
    {
        IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        public IActionResult Index()
        {
            return View(_assignmentService.All());
        }
        //---Init and Index-----------------------------------------------------------

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                _assignmentService.Create(assignment);
                return RedirectToAction("Index");
            }
            return View(assignment);
        }
    }
}