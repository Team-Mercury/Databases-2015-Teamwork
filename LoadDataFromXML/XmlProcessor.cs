namespace LoadDataFromXML
{
    using System.Collections.Generic;
    using Data.EF;
    using MongoDB.Driver;
    using System.Linq;

    public static class XmlProcessor
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "LaptopFactoryDB";

        public static void ProcessToMssql(IEnumerable<Product> products)
        {
            var db = new DatabaseContext();

            foreach (var product in products)
            {
                foreach (var order in product.Orders)
                {
                    var orderToAdd = new Models.EF.Order(order.Month, order.Count);

                    var modelOfOrder = db.Models
                                        .Where(m => m.Name == product.ModelName)
                                        .FirstOrDefault();

                    orderToAdd.Model = modelOfOrder;
                                           
                    db.Orders.Add(orderToAdd);
                }
            }

            db.SaveChanges();
        }

        public static void ProcessToMongo(IEnumerable<Product> products)
        {
            var db = GetDatabase(DatabaseHost, DatabaseName);

            foreach (var product in products)
            {
                foreach (var order in product.Orders)
                {
                    db.GetCollection<Order>("Orders").Insert(new Models.Mongo.Order(product.ModelName, order.Month, order.Count));
                }
            }
        }

        private static MongoDatabase GetDatabase(string fromHost, string name)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
    }
}
