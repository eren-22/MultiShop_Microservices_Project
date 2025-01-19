using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailDetailService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailService
{
	public class ProductDetailManager : IProductDetailService
	{
		private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
		private readonly IMapper _mapper;

		public ProductDetailManager(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			//Adım adım tabloya gidiyoruz. (Bağlantı -> Database -> Tablo)
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);

			_ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
		{
			var value = _mapper.Map<ProductDetail>(createProductDetailDTO);
			await _ProductDetailCollection.InsertOneAsync(value);
		}

		public async Task DeleteProductDetailAsync(string id)
		{
			await _ProductDetailCollection.DeleteOneAsync(c => c.ProductDetailId == id);
		}

		public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
		{
			var values = await _ProductDetailCollection.Find(c => true).ToListAsync();
			return _mapper.Map<List<ResultProductDetailDTO>>(values);
		}

		public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
		{
			var value = await _ProductDetailCollection.Find<ProductDetail>(c => c.ProductDetailId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDetailDTO>(value);
		}

		public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
		{
			var value = _mapper.Map<ProductDetail>(updateProductDetailDTO);
			await _ProductDetailCollection.FindOneAndReplaceAsync(c => c.ProductDetailId == updateProductDetailDTO.ProductDetailId, value); //Eşit olan id'yi bulduktan sonra value parametresindeki değerle değiştir.
		}
	}
}
