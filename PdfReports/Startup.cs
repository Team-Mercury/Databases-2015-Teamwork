namespace PdfReports
{
    using System;

    using PdfHandler;

    using Data.EF;

    public class Startup
    {
        public static void Main()
        {
            //int i = 1;
            //var dummyDb = new List<GraphicsCard>();
            //ExcelReportReadingProvider.ReadZippedReports("../../../ExcelSampleData/GraphicsCardsReports.zip", "../../../ExcelSampleData/reports", x =>
            //{
            //    Console.WriteLine("Loading report row {4}: {0}GB  {1}Ghz  {2}$  {3}", x[0], x[1], x[2], x[3], i++);
            //    dummyDb.Add(new GraphicsCard()
            //    {
            //        MemorySize = decimal.Parse(x[0].ToString()),
            //        ClockSpeed = decimal.Parse(x[1].ToString()),
            //        Price = decimal.Parse(x[2].ToString()),
            //        Manufacturer = x[3].ToString()
            //    });

            //});

            var pdfGenerator = new PdfReportGenerator();

            pdfGenerator.GenerateComputersReports("../../../", "Sales reports", new DatabaseContext());
        }
    }
}
