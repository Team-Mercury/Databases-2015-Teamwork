namespace Data.EF
{
    using System.Data.Entity;
    using Models.EF;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("LaptopFactory")
        {
        }

        public virtual IDbSet<Model> Models { get; set; }

        public virtual IDbSet<Maker> Makers { get; set; }

        public virtual IDbSet<Laptop> Laptops { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }
    }
}
