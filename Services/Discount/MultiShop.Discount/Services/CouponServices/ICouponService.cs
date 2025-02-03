using MultiShop.Discount.DTOs.CouponDTOs;

namespace MultiShop.Discount.Services.CouponServices
{
	public interface ICouponService
	{
		Task<List<ResultCouponDTO>> GetAllCouponAsync();
		Task CreateCouponAsync(CreateCouponDTO createCouponDTO);
		Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO);
		Task DeleteCouponAsync(int id);
		Task<GetByIdCouponDTO> GetByIdCouponAsync(int id);
	}
}
