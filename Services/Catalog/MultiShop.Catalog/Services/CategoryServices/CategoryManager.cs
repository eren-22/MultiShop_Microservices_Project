using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
	public class CategoryManager : ICategoryService
	{
		private readonly IMongoCollection<Category> _categoryCollection;
		private readonly IMapper _mapper;

		public CategoryManager(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			//Adım adım tabloya gidiyoruz. (Bağlantı -> Database -> Tablo)
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			
			_categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
			_mapper = mapper;
		}

		public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
		{
			var value = _mapper.Map<Category>(createCategoryDTO);
			await _categoryCollection.InsertOneAsync(value);
		}

		public async Task DeleteCategoryAsync(string id)
		{
			await _categoryCollection.DeleteOneAsync(c => c.CategoryId == id); 
		}

		public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
		{
			var values = await _categoryCollection.Find(c => true).ToListAsync();
			return _mapper.Map<List<ResultCategoryDTO>>(values);
		}

		public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
		{
			var value = await _categoryCollection.Find<Category>(c => c.CategoryId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdCategoryDTO>(value);
		}

		public async Task UpdateCategoryAsync(UpdateCatgoryDTO updateCategoryDTO)
		{
			var value = _mapper.Map<Category>(updateCategoryDTO);
			await _categoryCollection.FindOneAndReplaceAsync(c => c.CategoryId == updateCategoryDTO.CategoryId, value); //Eşit olan id'yi bulduktan sonra value parametresindeki değerle değiştir.
		}
	}
}