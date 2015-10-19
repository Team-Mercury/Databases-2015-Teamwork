using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReportLoader;
using Models.EF;

namespace ImportExcelData
{
    using Data.EF;
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                int i = 1;
                ExcelReportReadingProvider.ReadZippedReports("../../../ExcelSampleData/GraphicsCardsReports.zip", "../../../ExcelSampleData/reports", x =>
                {
                    Console.WriteLine("Loading report row {4}: {0}GB  {1}Ghz  {2}$  {3}", x[0], x[1], x[2], x[3], i++);
                    db.GraphicsCards.Add(new GraphicsCard()
                    {
                        MemorySize = decimal.Parse(x[0].ToString()),
                        ClockSpeed = decimal.Parse(x[1].ToString()),
                        Price = decimal.Parse(x[2].ToString()),
                        Manufacturer = x[3].ToString()
                    });

                });

                db.SaveChanges();
            }
        }
    }
}
