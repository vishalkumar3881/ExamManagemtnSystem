using System.ComponentModel.DataAnnotations;

namespace ExamManagementSystem.Models
{
    public class AllClass
    {
    }
    public class User
    {
        [Required]
        public int Roles { get; set; }
        [Required]
        public string? Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}