using System.ComponentModel.DataAnnotations;

namespace Demo1.Model
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Position { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [Phone]
        public string ?Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }

        public List<Sale> ?Sales { get; set; } = new List<Sale>();

    }
}
