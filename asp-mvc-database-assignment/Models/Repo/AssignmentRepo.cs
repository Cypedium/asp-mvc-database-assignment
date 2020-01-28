﻿using asp_mvc_database_assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models.Repo
{
    public class AssignmentRepo : IAssignmentRepo
    {
        HandleStudentsDbContext _handleStudentsDbContext;
        public AssignmentRepo(HandleStudentsDbContext handleStudentsDbContext)
        {
            _handleStudentsDbContext = handleStudentsDbContext;
        }

        public Assignment Create(Assignment assignment)
        {
            _handleStudentsDbContext.Assignments.Add(assignment);

            _handleStudentsDbContext.SaveChanges();

            return assignment;
        }

        public Assignment Find(int id)
        {
            return _handleStudentsDbContext.Assignments.SingleOrDefault(assignment => assignment.Id == id);
        }
        public List<Assignment> All()
        {
            return _handleStudentsDbContext.Assignments.ToList();
        }

        public bool Remove(Assignment assignment)
        {
            var result = _handleStudentsDbContext.Assignments.Remove(assignment);

            _handleStudentsDbContext.SaveChanges();

            return true;      
        }

       
        public Assignment Update(Assignment assignment)
        {
            Assignment newAssignment = Find(assignment.Id);

            newAssignment.Title = assignment.Title;
            newAssignment.Description = assignment.Description;

            _handleStudentsDbContext.SaveChanges();

            return newAssignment;
        }
    }
}
