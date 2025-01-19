using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductService
{
	public class ProductManager : IProductService
	{
		private readonly IMongoCollection<Product> _productCollection;
		private readonly IMapper _mapper;

		public ProductManager(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);

			_productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductAsync(CreateProductDTO createProductDTO)
		{
			var value = _mapper.Map<Product>(createProductDTO);
			await _productCollection.InsertOneAsync(value);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _productCollection.DeleteOneAsync(p => p.ProductId == id);
		}

		public async Task<List<ResultProductDTO>> GetAllProductAsync()
		{
			var values = await _productCollection.Find(p => true).ToListAsync();
			return _mapper.Map<List<ResultProductDTO>>(values);
		}

		public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
		{
			var value = await _productCollection.Find<Product>(p => p.ProductId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDTO>(value);
		}

		public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
		{
			var value = _mapper.Map<Product>(updateProductDTO);
			await _productCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDTO.ProductId, value);
		}
	}
}