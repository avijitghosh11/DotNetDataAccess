using DotNetCore.RedisDB.API.Models;

namespace DotNetCore.RedisDB.API.Data
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student GetStudent(string id);
        void CreateStudent(Student student);
        void UpdateStudent(string id, Student student);
        void DeleteStudent(string id);
    }
}
