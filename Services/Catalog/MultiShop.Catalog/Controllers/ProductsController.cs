using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Constants;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Services.ProductService;

namespace MultiShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> ProductList()
		{
			var values = await _productService.GetAllProductAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(string id)
		{
			var value = await _productService.GetByIdProductAsync(id);
			return Ok(value);
		}

		[HttpPost("add")]
		public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
		{
			await _productService.CreateProductAsync(createProductDTO);
			return Ok(Messages.ProductAdded);
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProductAsync(id);
			return Ok(Messages.ProductDeleted);
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
		{
			await _productService.UpdateProductAsync(updateProductDTO);
			return Ok(Messages.ProductUpdated);
		}
	}
}
