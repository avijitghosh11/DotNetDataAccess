using DotNetCore.MongoDB.EFCore.API.Data;
using DotNetCore.MongoDB.EFCore.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.MongoDB.EFCore.API.Services
{
    public class TeacherService(MongoContext _context) : ITeacherService
    {
        
        public Teacher CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public void DeleteTeacher(string id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x=>x.Id.ToString() == id);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        public Teacher GetTeacher(string id)
        {
            return _context.Teachers.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
    }
}
