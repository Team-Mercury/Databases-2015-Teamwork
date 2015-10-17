namespace Models.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Order
    {
        public Order(string modelName, string month, int count)
        {
            this.ModelName = modelName;
            this.Month = month;
            this.Count = count;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ModelName { get; set; }

        public string Month { get; set; }

        public int Count { get; set; }
    }
}
