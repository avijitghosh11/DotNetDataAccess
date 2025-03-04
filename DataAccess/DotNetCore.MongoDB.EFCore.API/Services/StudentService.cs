using DotNetCore.MongoDB.EFCore.API.Data;
using DotNetCore.MongoDB.EFCore.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.MongoDB.EFCore.API.Services
{
    public class StudentService(MongoContext _context) : IStudentService
    {
        
        public Student CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(string id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id.ToString() == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public Student GetStudent(string id)
        {
            return _context.Students.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
