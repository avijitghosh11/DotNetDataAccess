using DotNetCore.MongoDB.API.Models;
using DotNetCore.MongoDB.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCore.MongoDB.API.Controllers
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
            
            if (_studentService.GetStudent(id) == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }
            _studentService.UpdateStudent(id, student);

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
