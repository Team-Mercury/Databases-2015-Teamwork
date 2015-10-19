using System;
using System.Collections.Generic;
using System.Linq;

using PdfHandler;

namespace ReadStuff
{
    using Models.EF;
    using Data.EF;

    class Program
    {
        static void Main(string[] args)
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

            var pdfGenerator = new PdfFileExporter();

            pdfGenerator.GenerateComputersReports("../../../gosho", "gosho.pdf", new DatabaseContext());
        }
    }
}
