using AutoMapper;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
		//Entitiyleri new'lemek yerine, entititylerin proplarını Dto'daki proplarla eşleştirecek.

		public GeneralMapping()
		{
			CreateMap<Category, ResultCategoryDTO>().ReverseMap();
			CreateMap<Category, CreateCategoryDTO>().ReverseMap();
			CreateMap<Category, UpdateCatgoryDTO>().ReverseMap();
			CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

			CreateMap<Product, ResultProductDetailDTO>().ReverseMap();
			CreateMap<Product, CreateProductDetailDTO>().ReverseMap();
			CreateMap<Product, UpdateProductDetailDTO>().ReverseMap();
			CreateMap<Product, GetByIdProductDetailDTO>().ReverseMap();

			CreateMap<ProductDetail, ResultProductDetailDTO>().ReverseMap();
			CreateMap<ProductDetail, CreateProductDetailDTO>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDTO>().ReverseMap();
			CreateMap<ProductDetail, GetByIdProductDetailDTO>().ReverseMap();

			CreateMap<ProductImage, ResultProductImageDTO>().ReverseMap();
			CreateMap<ProductImage, CreateProductImageDTO>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDTO>().ReverseMap();
			CreateMap<ProductImage, GetByIdProductImageDTO>().ReverseMap();
		}
	}
}
