using DotNetCore.EntityFrameWork.API.Models;

namespace DotNetCore.EntityFrameWork.API.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void CreateStudent(Student student);
        void UpdateStudent(int id, Student student);
        void DeleteStudent(int id);
    }
}
