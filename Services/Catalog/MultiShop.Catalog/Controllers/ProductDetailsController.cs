﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Constants;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailDetailService;

namespace MultiShop.Catalog.Controllers
{
	public class ProductDetailsController : Controller
	{
		private readonly IProductDetailService _productDetailService;

		public ProductDetailsController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductDetailList()
		{
			var values = await _productDetailService.GetAllProductDetailAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductDetailById(string id)
		{
			var value = await _productDetailService.GetByIdProductDetailAsync(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createProductDetailDTO)
		{
			//Mappleme yaptığımız için;
			//ProductDetail ProductDetail = new ProductDetail();
			//ProductDetail.ProductDetailName = createProductDetailDTO.ProductDetailName;	YAPMAMIZA GEREK KALMIYOR!

			await _productDetailService.CreateProductDetailAsync(createProductDetailDTO);
			return Ok(Messages.ProductDetailAdded);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProductDetail(string id)
		{
			await _productDetailService.DeleteProductDetailAsync(id);
			return Ok(Messages.ProductDetailDeleted);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
		{
			await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO);
			return Ok(Messages.ProductDetailUpdated);
		}
	}
}
