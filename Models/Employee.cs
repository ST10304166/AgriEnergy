using System.ComponentModel.DataAnnotations;

namespace AgriEnergy.Models
{
    public class Employee
    {
        [Key] public int Id { get; set; }

        [Required, StringLength(100)] public string Name { get; set; }

        [Required, EmailAddress] public string Email { get; set; }

        [Required, DataType(DataType.Password)] public string Password { get; set; }

        public string Role { get; set; } = "Employee";
    }
}