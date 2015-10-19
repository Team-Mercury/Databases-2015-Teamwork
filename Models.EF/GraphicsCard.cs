namespace Models.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GraphicsCard
    {
        public int Id { get; set; }

        public decimal MemorySize { get; set; }

        public decimal ClockSpeed { get; set; }

        public decimal Price { get; set; }

        [StringLength(30)]
        public string Manufacturer { get; set; }
    }
}