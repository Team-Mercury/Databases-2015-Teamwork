namespace SqliteAndMySqlToExcel.Models
{
    using System.Data.Entity;

    public class LaptopAddonsContext : DbContext
    {
        public DbSet<AdditionalInfo> Info { get; set; }
    }
}
