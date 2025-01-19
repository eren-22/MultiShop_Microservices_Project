using MultiShop.Catalog.DTOs.ProductDetailDTOs;

namespace MultiShop.Catalog.Services.ProductDetailDetailService
{
	public interface IProductDetailService
	{
		Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync();
		Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
		Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
		Task DeleteProductDetailAsync(string id);
		Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id);
	}
}