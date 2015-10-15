namespace Models.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Laptop
    {
        public Laptop(string makerID, string modelID, decimal price, int quntity)
        {
            this.MakerID = makerID;
            this.ModelID = modelID;
            this.Price = price;
            this.Quantity = quntity;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string MakerID { get; set; }

        public string ModelID { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
