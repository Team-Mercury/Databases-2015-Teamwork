namespace SqliteAndMySqlToExcel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("reports")]
    public class Report
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("profit")]
        public string Profit { get; set; }
    }
}
