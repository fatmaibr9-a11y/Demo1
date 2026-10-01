using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Model
{
    public class Vehicle
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required]
      
        public decimal Price { get; set; }
        [Required]
        public int Mileage { get; set; }
        [MaxLength(17)]
        public string VIN { get; set; }
        [MaxLength(30)]
        public string ?FuelType { get; set; }
        [MaxLength(30)]
        public string ? Transmission { get; set; }
        [Required]
        public string Status { get; set; }

        [ForeignKey("Id")]
        public int CategoryId { get; set; }
        public Category ?Category { get; set; }

        [ForeignKey("Id")]
        public int SaleId { get; set; }
        public Sale?Sale { get; set; }

    }
}
