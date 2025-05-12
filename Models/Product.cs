using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergy.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Required, StringLength(100)] public string Name { get; set; }

        [Required, StringLength(50)] public string Category { get; set; }

        [Required, DataType(DataType.Date)] public DateTime ProductionDate { get; set; }

        [ForeignKey("Farmer")] public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }
    }
}