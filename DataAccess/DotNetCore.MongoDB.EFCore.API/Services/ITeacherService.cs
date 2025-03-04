using DotNetCore.MongoDB.EFCore.API.Models;
using System.Collections.Generic;

namespace DotNetCore.MongoDB.EFCore.API.Services
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacher(string id);
        Teacher CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(string id);
    }
}
