namespace MultiShop.Discount.DTOs.CouponDTOs
{
	public class GetByIdCouponDTO
	{
		public int CouponId { get; set; }
		public string Code { get; set; }
		public int Rate { get; set; } //İndirim oranı
		public bool IsActive { get; set; }
		public DateTime ValidDate { get; set; }
	}
}
