using DotNetCore.MongoDB.EFCore.API.Models;
using System.Collections.Generic;

namespace DotNetCore.MongoDB.EFCore.API.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        Student CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(string id);
    }
}
