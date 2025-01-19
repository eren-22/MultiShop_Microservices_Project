using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageImageService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageService
{
	public class ProductImageManager : IProductImageService
	{
		private readonly IMongoCollection<ProductImage> _ProductImageCollection;
		private readonly IMapper _mapper;

		public ProductImageManager(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			//Adım adım tabloya gidiyoruz. (Bağlantı -> Database -> Tablo)
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);

			_ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
		{
			var value = _mapper.Map<ProductImage>(createProductImageDTO);
			await _ProductImageCollection.InsertOneAsync(value);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _ProductImageCollection.DeleteOneAsync(c => c.ProductImageId == id);
		}

		public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
		{
			var values = await _ProductImageCollection.Find(c => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDTO>>(values);
		}

		public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
		{
			var value = await _ProductImageCollection.Find<ProductImage>(c => c.ProductImageId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductImageDTO>(value);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
		{
			var value = _mapper.Map<ProductImage>(updateProductImageDTO);
			await _ProductImageCollection.FindOneAndReplaceAsync(c => c.ProductImageId == updateProductImageDTO.ProductImageId, value); //Eşit olan id'yi bulduktan sonra value parametresindeki değerle değiştir.
		}
	}
}
