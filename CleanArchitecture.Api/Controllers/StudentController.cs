﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await studentService.GetByIdAsync(id);
            return Ok(student);
        }
    }
}