using System.ComponentModel.DataAnnotations;

namespace Demo1.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ?Description { get; set; }

        public List<Vehicle> ?Vehicles { get; set; } = new List<Vehicle>();
    }
}
