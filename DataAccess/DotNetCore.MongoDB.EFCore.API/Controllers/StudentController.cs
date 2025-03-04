using DotNetCore.MongoDB.EFCore.API.Models;
using DotNetCore.MongoDB.EFCore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DotNetCore.MongoDB.EFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            var students = _studentService.GetStudents();
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
           _studentService.CreateStudent(student);
            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var std = _studentService.GetStudent(id);
            if (std == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }

            std.Courses = student.Courses;
            std.IsGraduated = student.IsGraduated;
            std.Gender = student.Gender;
            std.Age = student.Age;
            std.Name = student.Name;

            _studentService.UpdateStudent(std);

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_studentService.GetStudent(id) == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }
            _studentService.DeleteStudent(id);

            return Ok($"Student with id {id} is deleted.");
        }
    }
}
