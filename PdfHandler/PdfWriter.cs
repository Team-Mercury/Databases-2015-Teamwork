namespace PdfHandler
{
    using System;
    using System.IO;
    using System.Linq;
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using Models.EF;
    using Data.EF;

    public class PdfFileExporter
    {
        private const string ManufacturerColumnHeader = "Manufacturer";
        private const string ModelColumnHeader = "Model";
        private const string PriceColumnHeader = "Price";
        private const string ClassColumnHeader = "Class";
        private const int PdfTableSize = 4;

        public void GenerateComputersReports(string filePath, string fileName, DatabaseContext db)
        {
            fileName = AddUniqueFilenameSuffix(fileName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var output = new FileStream(filePath + fileName, FileMode.Create, FileAccess.Write);
            var writer = PdfWriter.GetInstance(document, output);  // never used opens process only

            PdfPTable table = this.CreateComputerReportsTable();
            this.AddComputerReportsTableHeader(table);
            this.AddComputerReportsTableColumns(table);
            this.FillComputerReportsTableData(table, db);

            document.Open();
            document.Add(table);
            document.Close();
        }

        private static string AddUniqueFilenameSuffix(string fileName)
        {
            DateTime currentDate = DateTime.Now;
            string fileNameSuffix = string.Format(
                "-{0}.{1}.{2}-{3}.{4}.{5}.pdf",
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
                        PriceColumnHeader = c.Price,
                        ClassColumnHeader = "gosho"
                    })
                .ToList();

            foreach (var computer in computersReports)
            {
                table.AddCell(computer.ManufacturerColumnHeader);
                table.AddCell(computer.ModelColumnHeader.Name);
                table.AddCell(computer.PriceColumnHeader + " $");
                table.AddCell(computer.ClassColumnHeader);
            }
        }

        private void AddComputerReportsTableColumns(PdfPTable table)
        {
            table.AddCell(ManufacturerColumnHeader);
            table.AddCell(ModelColumnHeader);
            table.AddCell(PriceColumnHeader);
            table.AddCell(ClassColumnHeader);
        }

        private void AddComputerReportsTableHeader(PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase("Computer Reports"));
            cell.Colspan = PdfTableSize;
            cell.HorizontalAlignment = 1;
            cell.BackgroundColor = BaseColor.GRAY;
            table.AddCell(cell);
        }

        private PdfPTable CreateComputerReportsTable()
        {
            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            float[] widths = { 3f, 3f, 3f, 3f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;
            return table;
        }
    }
}