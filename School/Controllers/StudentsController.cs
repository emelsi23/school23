using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Entities;
using School.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Controllers
{
    [Route("user")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IService<Student> _studentService;
        public StudentsController(IService<Student> service)
        {
            _studentService = service;
        }
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentService.GetAll();
        }
        [HttpGet("{id}")]
        public Student GetById([FromRoute] Guid id)
        {
            return _studentService.GetById(id);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] Student student)
        {
            _studentService.Add(student);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Student student, Guid id)
        {
            _studentService.Update(id, student);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute]Guid id)
        {
            _studentService.Remove(id);
            return Ok();
        }
    }
}
