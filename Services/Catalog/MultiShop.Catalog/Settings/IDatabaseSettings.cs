﻿namespace MultiShop.Catalog.Settings
{
	public interface IDatabaseSettings
	{

		//appsettings.json'da bağlantı gerçekleştirilir.
		//Crud işlemi gerçekleştiirken bu isimlere ihtiyacımız olacak.
		public string CategoryCollectionName { get; set; }
		public string ProductCollectionName { get; set; }
		public string ProductDetailCollectionName { get; set; }
		public string ProductImageCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
