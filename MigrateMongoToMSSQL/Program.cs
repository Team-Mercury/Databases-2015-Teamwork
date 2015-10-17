namespace MigrateMongoToMSSQL
{
    using System.Collections.Generic;
    using Data.EF;
    using Models.EF;
    using MongoDB.Driver;
    using System.Linq;

    public class Program
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "LaptopFactoryDB";

        private static MongoDatabase GetDatabase(string fromHost, string name)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        private static ICollection<string> MigrateMakersTable(DatabaseContext sqlDB, MongoDatabase mongoDB)
        {
            ICollection<string> makerIDsMongo = new HashSet<string>();
            var makersMongo = mongoDB.GetCollection<Models.Mongo.Maker>("Makers").FindAll().Select(m => m).ToList();

            foreach (var maker in makersMongo)
            {
                makerIDsMongo.Add(maker.Id);

                var newMaker = new Models.EF.Maker(maker.Name, maker.Phone, maker.Email);
                sqlDB.Makers.Add(newMaker);
            }

            return makerIDsMongo;
        }

        private static ICollection<string> MigrateModelsTable(DatabaseContext sqlDB, MongoDatabase mongoDB)
        {
            ICollection<string> modelIDsMongo = new HashSet<string>();
            var modelsMongo = mongoDB.GetCollection<Models.Mongo.Model>("Models").FindAll().Select(m => m).ToList();

            foreach (var Order in modelsMongo)
            {
                modelIDsMongo.Add(Order.Id);

                var newModel = new Models.EF.Model(Order.Name, Order.CPU, Order.RAM, Order.HDD);
                sqlDB.Models.Add(newModel);
            }
             
            return modelIDsMongo;
        }

        private static void MigrateLaptopsTable(DatabaseContext sqlDB, MongoDatabase mongoDB, ICollection<string> makerIDsMongo, ICollection<string> modelIDsMongo)
        {
            var laptopsMongo = mongoDB.GetCollection<Models.Mongo.Laptop>("Laptops").FindAll().Select(l => l).ToList();
            var makerIDs = makerIDsMongo.ToList();
            var modelIDs = modelIDsMongo.ToList();

            foreach (var laptop in laptopsMongo)
            {
                var makerIndexID = makerIDs.FindIndex(l => l == laptop.MakerID);
                var modelIndexID = modelIDs.FindIndex(l => l == laptop.ModelID);
                var newLaptop = new Models.EF.Laptop(laptop.Price, laptop.Quantity);
                newLaptop.Maker = sqlDB.Makers.First(m => m.Id == makerIndexID + 1);
                newLaptop.Model = sqlDB.Models.First(m => m.Id == modelIndexID + 1);
                sqlDB.Laptops.Add(newLaptop);
            }
        }

        public static void Main()
        {
            var sqlDB = new DatabaseContext();
            var mongoDB = GetDatabase(DatabaseHost, DatabaseName);
           
            var makerIDsMongo = MigrateMakersTable(sqlDB, mongoDB);
            var modelIDsMongo = MigrateModelsTable(sqlDB, mongoDB);

            sqlDB.SaveChanges();

            MigrateLaptopsTable(sqlDB, mongoDB, makerIDsMongo, modelIDsMongo);

            sqlDB.SaveChanges();
        }
    }
}
