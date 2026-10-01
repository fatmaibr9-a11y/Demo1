using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Model
{
    public class Sale
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } 
        [MaxLength(300)]
        public string ?Notes { get; set; }

        [ForeignKey("Id")]
        public int customerId { get; set; }
        public Customer ?Customer { get; set; }

        [ForeignKey("Id")]
        public int EmployeeId { get; set; }
        public Employee ?Employee { get; set; }
        [ForeignKey("Id")]
        public int VehicleId { get; set; }
        public Vehicle ?Vehicle { get; set; }
      
    }
}
