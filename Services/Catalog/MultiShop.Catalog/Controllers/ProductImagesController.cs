using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Constants;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageService;

namespace MultiShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImagesController : Controller
	{
		private readonly IProductImageService _productImageService;

		public ProductImagesController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> ProductImageList()
		{
			var values = await _productImageService.GetAllProductImageAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductImageById(string id)
		{
			var value = await _productImageService.GetByIdProductImageAsync(id);
			return Ok(value);
		}

		[HttpPost("add")]
		public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
		{
			//Mappleme yaptığımız için;
			//ProductImage ProductImage = new ProductImage();
			//ProductImage.ProductImageName = createProductImageDTO.ProductImageName;	YAPMAMIZA GEREK KALMIYOR!

			await _productImageService.CreateProductImageAsync(createProductImageDTO);
			return Ok(Messages.ProductImageAdded);
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteProductImage(string id)
		{
			await _productImageService.DeleteProductImageAsync(id);
			return Ok(Messages.ProductImageDeleted);
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
		{
			await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
			return Ok(Messages.ProductImageUpdated);
		}
	}
}
