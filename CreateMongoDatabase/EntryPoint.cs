namespace CreateMongoDatabase
{
    using Models.Mongo;
    using MongoDB.Driver;
    using MongoDB.Bson;
    using System;
    using System.Linq;

    public class EntryPoint
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "LaptopFactoryDB";

        private static MongoDatabase GetDatabase(string fromHost, string name)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
        
        private static void CreateMakersTable(MongoDatabase db)
        {
            var makersCollection = db.GetCollection<Maker>("Makers");
            makersCollection.InsertBatch<Maker>(new []{
                new Maker("Acer", "+1234567890", "sales_contact@acer.com"),
                new Maker("Asus", "+1234567890", "sales_contact@asus.com"),
                new Maker("HP", "+1234567890", "sales_contact@hp.com"),
                new Maker("Toshiba", "+1234567890", "sales_contact@toshiba.com"),
                new Maker("Lenovo", "+1234567890", "sales_contact@lenovo.com"),
                new Maker("MSI", "+1234567890", "sales_contact@msi.com"),
                new Maker("Apple", "+1234567890", "sales_contact@apple.com"),
                new Maker("Dell", "+1234567890", "sales_contact@dell.com"),
                new Maker("Samsung", "+1234567890", "sales_contact@acer.com"),
                new Maker("Razer", "+1234567890", "sales_contact@razer.com"),
                new Maker("LG", "+1234567890", "sales_contact@lg.com"),
                new Maker("Medion", "+1234567890", "sales_contact@medion.com"),
                new Maker("Vizio", "+1234567890", "sales_contact@vizio.com"),
                new Maker("Sharp", "+1234567890", "sales_contact@sharp.com"),
            });
        }

        private static void CreateModelsTable(MongoDatabase db)
        {
            var modelsCollection = db.GetCollection<Model>("Models");
            modelsCollection.InsertBatch<Model>(new[]{
                new Model("A1", "Intel Core i7-4712MQ", 4, 1000),
                new Model("A2", "Intel Core i7-4712MQ", 8, 1000),
                new Model("A3", "Intel Core i7-4712MQ", 16, 1000),
                new Model("E5", "Intel Core i5-5500U", 4, 500),
                new Model("E6", "Intel Core i5-5500U", 4, 750),
                new Model("E1", "Intel Core i5-5500U", 6, 1000),
                new Model("E2", "Intel Core i5-5500U", 8, 1008),
                new Model("E3", "Intel Core i5-5500U", 4, 2000),
                new Model("S1", "Intel Core i3-4005U", 6, 500),
                new Model("S2", "Intel Core i3-4005U", 8, 500),
                new Model("S3", "Intel Core i3-4005U", 16, 1008),
                new Model("S4", "Intel Core i7-6700K", 6, 1256),
                new Model("S5", "Intel Core i7-6700K", 8, 1128),
                new Model("S7", "Intel Core i7-6700K", 16, 2000),
                new Model("S8", "Intel Core i7-6700K", 8, 2256),
                new Model("S9", "Intel Core i7-6700K", 8, 1000),
                new Model("Y7", "NTEL CELERON N3050 DUAL CORE", 4, 1000),
                new Model("Y7", "NTEL CELERON N3050 DUAL CORE", 8, 1000),
                new Model("Y7", "NTEL CELERON N3050 DUAL CORE", 8, 500),
                new Model("Y7", "NTEL CELERON N3050 DUAL CORE", 6, 1008),
            });
        }

        private static void CreateLaptopsTable(MongoDatabase db)
        {
            var laptopsCollection = db.GetCollection<Laptop>("Laptops");
            var modelsIDs = db.GetCollection<Model>("Models").FindAll().Select(x => x.Id).ToList();
            var makersIDs = db.GetCollection<Maker>("Makers").FindAll().Select(x => x.Id).ToList();

            for (int i = 0; i < makersIDs.Count; i++)
            {
                laptopsCollection.InsertBatch<Laptop>(new[]{
                    new Laptop(makersIDs[i], modelsIDs[i], 1000 - i * i, (int)Math.Pow((i - 4), 2)),
                    new Laptop(makersIDs[i], modelsIDs[i + 3], 1500 - i * i, (int)Math.Pow((i - 5), 2)),
                    new Laptop(makersIDs[i], modelsIDs[i + 3], 2500 - i * i, (int)Math.Pow((i - 6), 2)),
                });
            }
        }

        private static void CreateLaptopFactoryDatabase(MongoDatabase db)
        {
            db.Drop();
            CreateMakersTable(db);
            CreateModelsTable(db);
            CreateLaptopsTable(db);
        }

        public static void Main()
        {
            var db = GetDatabase(DatabaseHost, DatabaseName);
            CreateLaptopFactoryDatabase(db);
        }
    }
}
