namespace CuponMicroScerviceAPI.Model.CuponDto
{
    public class CuponDto
    {

        public int CuponId { get; set; }

        public string CuponCode { get; set; }

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
