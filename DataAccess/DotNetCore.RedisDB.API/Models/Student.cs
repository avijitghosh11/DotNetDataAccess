using System.ComponentModel.DataAnnotations;

namespace DotNetCore.RedisDB.API.Models
{
    public class Student
    {
        [Required]
        public string Id { get; set; } = $"Student:{Guid.NewGuid().ToString()}";
        public string Name { get; set; } = string.Empty;
        public bool IsGraduated { get; set; }
        public string[]? Courses { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public Address Address { get; set; }

    }
}
