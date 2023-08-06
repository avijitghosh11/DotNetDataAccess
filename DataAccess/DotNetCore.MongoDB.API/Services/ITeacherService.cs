using DotNetCore.MongoDB.API.Models;

namespace DotNetCore.MongoDB.API.Services
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacher(string id);
        Teacher CreateTeacher(Teacher teacher);
        void UpdateTeacher(string id, Teacher teacher);
        void DeleteTeacher(string id);
    }
}
