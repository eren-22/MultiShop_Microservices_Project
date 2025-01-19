using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Constants;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
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

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
		{
			//Mappleme yaptığımız için;
			//Category category = new Category();
			//category.CategoryName = createCategoryDTO.CategoryName;	YAPMAMIZA GEREK KALMIYOR!

			await _categoryService.CreateCategoryAsync(createCategoryDTO);
			return Ok(Messages.CategoryAdded);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return Ok(Messages.CategoryDeleted);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDTO);
			return Ok(Messages.CategoryUpdated);
		}
	}
}
