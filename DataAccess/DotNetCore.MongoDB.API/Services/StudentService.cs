using DotNetCore.MongoDB.API.DatabaseCore;
using DotNetCore.MongoDB.API.Models;
using MongoDB.Driver;

namespace DotNetCore.MongoDB.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _studentCollection;

        public StudentService(IAppDatabaseSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _studentCollection = database.GetCollection<Student>(settings.StudentCollection);
        }
        public Student CreateStudent(Student student)
        {
            _studentCollection.InsertOne(student);
            return student;
        }

        public void DeleteStudent(string id)
        {
            _studentCollection.DeleteOne(x => x.Id == id);
        }

        public Student GetStudent(string id)
        {
           return _studentCollection.Find(x=>x.Id == id).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return _studentCollection.Find(x=>true).ToList();
        }

        public void UpdateStudent(string id, Student student)
        {
            _studentCollection.ReplaceOne(x => x.Id == id, student);
        }
    }
}
