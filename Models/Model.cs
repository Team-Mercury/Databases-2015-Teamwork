namespace Models.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Model
    {
        public Model(string name, string cpu, int ram, int hdd)
        {
            this.Name = name;
            this.CPU = cpu;
            this.RAM = ram;
            this.HDD = hdd;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string CPU { get; set; }

        public int RAM { get; set; }

        public int HDD{ get; set; }
    }
}
