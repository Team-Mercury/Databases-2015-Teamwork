namespace Models.EF
{
    public class Laptop
    {
        public Laptop(string makerID, string modelID, decimal price, int quntity)
        {
            this.MakerID = makerID;
            this.ModelID = modelID;
            this.Price = price;
            this.Quantity = quntity;
        }

        public string Id { get; set; }

        public string MakerID { get; set; }

        public virtual Maker Maker { get; set; }

        public string ModelID { get; set; }

        public virtual Model Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
