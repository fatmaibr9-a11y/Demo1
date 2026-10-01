using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Model
{
    public class CustomerProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?City { get; set; }
        [Required]
        [MaxLength(50)]
        
        public string ?Nationality { get; set; }
        public DateTime ? DateOfBirth { get; set; }
        [ForeignKey("Id")]
        public int CustomerId { get; set; }
        public Customer?Customer { get; set; }
    }
}
