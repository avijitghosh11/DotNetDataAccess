using DotNetCore.RedisDB.API.Data;
using DotNetCore.RedisDB.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.RedisDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            var students = _studentRepository.GetStudents();
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentRepository.GetStudent(id);
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
            _studentRepository.CreateStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {

            if (_studentRepository.GetStudent(id) == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }
            _studentRepository.UpdateStudent(id, student);

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_studentRepository.GetStudent(id) == null)
            {
                return NotFound($"Student with id {id} is not found.");
            }

            _studentRepository.DeleteStudent(id);

            return Ok($"Student with id {id} is deleted.");
        }
    }
}
