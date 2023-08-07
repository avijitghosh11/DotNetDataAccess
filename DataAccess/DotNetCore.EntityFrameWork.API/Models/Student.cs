using System.ComponentModel.DataAnnotations;

namespace DotNetCore.EntityFrameWork.API.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;        
        public bool IsGraduated { get; set; }        
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
    }
}
