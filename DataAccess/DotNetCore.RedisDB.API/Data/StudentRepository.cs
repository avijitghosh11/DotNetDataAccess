using DotNetCore.RedisDB.API.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace DotNetCore.RedisDB.API.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConnectionMultiplexer _connection;
        private readonly IDatabase _db;

        public StudentRepository(IConnectionMultiplexer connection)
        {
            _connection = connection;
            _db = _connection.GetDatabase();
        }
        public List<Student> GetStudents()
        {
            RedisKey[] keys = _db.Multiplexer.GetServer(_connection.Configuration).Keys(pattern: "Student:*").ToArray();
            var result = _db.StringGet(keys).Select(d => JsonSerializer.Deserialize<Student>(d)).ToList();
            return result;
        }
        public Student GetStudent(string id)
        {
            return JsonSerializer.Deserialize<Student>(_db.StringGet(id));

        }
        public void CreateStudent(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _db.StringSet(student.Id, JsonSerializer.Serialize(student));

        }

        public void UpdateStudent(string id, Student student)
        {
            var data = GetStudent(id);
            data.Name = student.Name;
            data.Age = student.Age;
            data.Courses = student.Courses;
            data.IsGraduated = student.IsGraduated;
            data.Gender = student.Gender;
            data.Address = student.Address;
            _db.StringSet(student.Id, JsonSerializer.Serialize(data));
        }

        public void DeleteStudent(string id)
        {
            _db.KeyDelete(id);
        }
        
    }
}
