using DotNetCore.MongoDB.API.DatabaseCore;
using DotNetCore.MongoDB.API.Models;
using MongoDB.Driver;

namespace DotNetCore.MongoDB.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IMongoCollection<Teacher> _teacherCollection;

        public TeacherService(IAppDatabaseSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _teacherCollection = database.GetCollection<Teacher>(settings.TeacherCollection);
        }
        public Teacher CreateTeacher(Teacher teacher)
        {
            _teacherCollection.InsertOne(teacher);
            return teacher;
        }

        public void DeleteTeacher(string id)
        {
            _teacherCollection.DeleteOne(x => x.Id == id);
        }

        public Teacher GetTeacher(string id)
        {
            return _teacherCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Teacher> GetTeachers()
        {
            return _teacherCollection.Find(x => true).ToList();
        }

        public void UpdateTeacher(string id, Teacher teacher)
        {
            _teacherCollection.ReplaceOne(x => x.Id == id, teacher);
        }
    }
}
