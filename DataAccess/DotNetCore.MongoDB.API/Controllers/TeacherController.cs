using DotNetCore.MongoDB.API.Models;
using DotNetCore.MongoDB.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.MongoDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<List<Teacher>> Get()
        {
            var teachers = _teacherService.GetTeachers();
            return teachers;
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(string id)
        {
            var teacher = _teacherService.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound($"Teacher with id {id} is not found.");
            }
            return teacher;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<Teacher> Post([FromBody] Teacher teacher)
        {
            _teacherService.CreateTeacher(teacher);
            return CreatedAtAction(nameof(Get), new { id = teacher.Id }, teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Teacher teacher)
        {

            if (_teacherService.GetTeacher(id) == null)
            {
                return NotFound($"Teacher with id {id} is not found.");
            }
            _teacherService.UpdateTeacher(id, teacher);

            return NoContent();
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (_teacherService.GetTeacher(id) == null)
            {
                return NotFound($"Teacher with id {id} is not found.");
            }
            _teacherService.DeleteTeacher(id);

            return Ok($"Teacher with id {id} is deleted.");
        }
    }
}
