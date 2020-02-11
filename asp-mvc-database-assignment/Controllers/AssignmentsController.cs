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
        //---Init and Index-----------------------------------------------------------
        IAssignmentService _assignmentService;
        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        public IActionResult Index()
        {
            return View(_assignmentService.All());
        }
        //-----------------------------------------------------------------------------

        //Create-----------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------

        //-----------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id)
        {
            Assignment assignmentDetails = _assignmentService.Find(id);
            if (assignmentDetails == null)
            {
                return RedirectToAction("Index");
            }
            return View(assignmentDetails);
        }
        [HttpPost]
        public IActionResult Details() //uses this postaction for back to option
        {
            return View("Index", _assignmentService.All());
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            Assignment aAssignment = _assignmentService.Find(id);
            if (aAssignment == null)
            {
                return RedirectToAction("Index");
            }
            return View(aAssignment);
        }

        [HttpPost]
        public IActionResult Remove(Student student)
        {
            bool result = _assignmentService.Remove(student.Id);

            if (result)
            {
                ViewBag.msg = "Your Assignment has been succesfully removed";
            }
            else
            {
                ViewBag.msg = "Unable to remove Assignment";
            }

            return View("Index", _assignmentService.All());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Assignment assignment = _assignmentService.Find(id);
            if (assignment == null)
            {
                ViewBag.msg = "The Assignment was not found";
                return View(_assignmentService.All());
            }
            return View(assignment);
        }
        [HttpPost]
        public IActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _assignmentService.Update(assignment);
                return RedirectToAction("Index");
            }
            return View(assignment);
        }
    }
}