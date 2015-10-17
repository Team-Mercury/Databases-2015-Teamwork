namespace Models.EF
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order(string modelName, string month, int count)
        {
            this.ModelName = modelName;
            this.Month = month;
            this.Count = count;
        }

        public Order()
        {
        }

        public int Id { get; set; }

        [StringLength(40)]
        public string ModelName { get; set; } 

        public virtual Model Model { get; set; }

        [StringLength(8)]
        public string Month { get; set; }

        public int Count { get; set; }
    }
}
