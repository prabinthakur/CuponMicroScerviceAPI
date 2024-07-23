using System.ComponentModel.DataAnnotations;

namespace CuponMicroScerviceAPI.Model
{
    public class Cupons
    {
        [Key]
        public int CuponId { get; set; }

        [Required]
        public string CuponCode { get; set; }
        [Required]

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }

      
    }
}
