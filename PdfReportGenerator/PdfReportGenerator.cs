namespace PdfHandler
{
    using System;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using Data.EF;

    public class PdfReportGenerator
    {
        private const string ManufacturerColumnHeader = "Manufacturer";
        private const string ModelColumnHeader = "Model";
        private const string PriceColumnHeader = "Price";
        private const string ReportsTitle = "Laptop sales";
        private const string fileExtensionsFormat = "- {0}-{1}-{2} {3}-{4}-{5}.pdf";
        private const int PdfTableSize = 3;

        public void GenerateComputersReports(string filePath, string fileName, DatabaseContext db)
        {
            fileName = MakeUniqueFileName(fileName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var output = new FileStream(filePath + fileName, FileMode.Create, FileAccess.Write);
            var writer = PdfWriter.GetInstance(document, output);

            PdfPTable table = this.GetReportsTable();
            this.AddComputerReportsTableHeader(table);
            this.AddComputerReportsTableColumns(table);
            this.FillComputerReportsTableData(table, db);

            document.Open();
            document.Add(table);
            document.Close();
        }

        private static string MakeUniqueFileName(string fileName)
        {
            DateTime currentDate = DateTime.Now;
            string fileNameSuffix = string.Format(fileExtensionsFormat,
                                                  currentDate.Day,
                                                  currentDate.Month,
                                                  currentDate.Year,
                                                  currentDate.Hour,
                                                  currentDate.Minute,
                                                  currentDate.Second);

            fileName = fileName + fileNameSuffix;
            return fileName;
        }

        private void FillComputerReportsTableData(PdfPTable table, DatabaseContext db)
        {
            var computersReports = db.Laptops
                .Select(c =>
                    new
                    {
                        ManufacturerColumnHeader = c.Maker.Name,
                        ModelColumnHeader = c.Model,
                        PriceColumnHeader = c.Price
                    })
                .ToList();

            foreach (var computer in computersReports)
            {
                table.AddCell(computer.ManufacturerColumnHeader);
                table.AddCell(computer.ModelColumnHeader.Name);
                table.AddCell(computer.PriceColumnHeader + " $");
            }
        }

        private void AddComputerReportsTableColumns(PdfPTable table)
        {
            table.AddCell(ManufacturerColumnHeader);
            table.AddCell(ModelColumnHeader);
            table.AddCell(PriceColumnHeader);
        }

        private void AddComputerReportsTableHeader(PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase(ReportsTitle));
            cell.Colspan = PdfTableSize;
            cell.HorizontalAlignment = 1;
            cell.BackgroundColor = BaseColor.BLUE;
            table.AddCell(cell);
        }

        private PdfPTable GetReportsTable()
        {
            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            float[] widths = { 3f, 3f, 3f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            return table;
        }
    }
}