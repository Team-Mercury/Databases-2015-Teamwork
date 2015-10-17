namespace LoadDataFromXML
{
    using System;
    using System.Collections.Generic;
    using Models.Mongo;
    using MongoDB.Driver;

    public class MongoDataImporter : IDataImporter<Order>
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "LaptopFactoryDB";

        private static MongoDatabase GetDatabase(string fromHost, string name)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public void ImportOrdersData(ICollection<Order> orders)
        {
            var mongoDB = GetDatabase(DatabaseHost, DatabaseName);

            foreach (var order in orders)
            {
                mongoDB.GetCollection<Order>("Orders").Insert(order);
            }
        }
    }
}
