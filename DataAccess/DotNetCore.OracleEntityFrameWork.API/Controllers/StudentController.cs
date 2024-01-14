using DotNetCore.OracleEntityFrameWork.API.Models;
using DotNetCore.OracleEntityFrameWork.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.OracleEntityFrameWork.API.Controllers
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
        public ActionResult<Student> Get(int id)
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
            return NoContent();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student student)
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
        public ActionResult Delete(int id)
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
