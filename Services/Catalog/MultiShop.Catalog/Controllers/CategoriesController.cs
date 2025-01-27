using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Constants;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _categoryService.GetAllCategoryAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(string id)
		{
			var value = await _categoryService.GetByIdCategoryAsync(id);
			return Ok(value);
		}

		[HttpPost("add")]
		public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
		{
			//Mappleme yaptığımız için;
			//Category category = new Category();
			//category.CategoryName = createCategoryDTO.CategoryName;	YAPMAMIZA GEREK KALMIYOR!

			await _categoryService.CreateCategoryAsync(createCategoryDTO);
			return Ok(Messages.CategoryAdded);
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return Ok(Messages.CategoryDeleted);
		}

		[HttpPut("update")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDTO);
			return Ok(Messages.CategoryUpdated);
		}
	}
}
