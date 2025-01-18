using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
	public class Category
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)] //Unique
		public string CategoryId { get; set; }  //Guid
		public string CategoryName { get; set; }
	}
}
