using System.ComponentModel.DataAnnotations;

namespace AgriEnergy.Models
{
    public class Farmer
    {
        [Key] public int Id { get; set; }

        [Required, StringLength(100)] public string Name { get; set; }

        [Required, EmailAddress] public string Email { get; set; }

        [Required, DataType(DataType.Password)] public string Password { get; set; }

        [Required, StringLength(200)] public string Address { get; set; }

        [Required, Phone] public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public string Role { get; set; } = "Farmer";

        public ICollection<Product> Products { get; set; }
    }
}