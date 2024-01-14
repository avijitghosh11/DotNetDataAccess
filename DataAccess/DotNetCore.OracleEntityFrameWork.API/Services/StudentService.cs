using DotNetCore.OracleEntityFrameWork.API.DatabaseContext;
using DotNetCore.OracleEntityFrameWork.API.Models;

namespace DotNetCore.OracleEntityFrameWork.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var data = _context.Students.FirstOrDefault(s=>s.Id==id);
            if (data != null)
            {
                _context.Students.Remove(data);
                _context.SaveChanges();
            }
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(int id, Student student)
        {
            var data = _context.Students.FirstOrDefault(s => s.Id == id);
            if (data != null)
            {
                data.Age = student.Age;
                data.Name = student.Name;
                data.IsGraduated = student.IsGraduated;
                data.Gender = student.Gender;

                _context.Students.Update(data);
                _context.SaveChanges();
            }
        }
    }
}
