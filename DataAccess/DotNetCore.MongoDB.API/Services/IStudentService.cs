using DotNetCore.MongoDB.API.Models;

namespace DotNetCore.MongoDB.API.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        Student CreateStudent(Student student);
        void UpdateStudent(string id,Student student);
        void DeleteStudent(string id);
    }
}
