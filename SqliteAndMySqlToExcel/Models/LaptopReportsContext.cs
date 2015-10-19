namespace SqliteAndMySqlToExcel.Models
{
    using System.Data.Entity;

    public class LaptopReportsContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
    }
}
