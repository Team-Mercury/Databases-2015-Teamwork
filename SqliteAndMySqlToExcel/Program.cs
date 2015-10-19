namespace SqliteAndMySqlToExcel
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    using Excel = Microsoft.Office.Interop.Excel;

    public class Program
    {
        private const string EXCEL_PATH = "D:\\data.xlsx";

        public static void Main(string[] args)
        {
            using (var db = new LaptopAddonsContext())
            {
                var additionalData = db.Info.ToList();

                SaveToExcelSpreadsheet(additionalData);
            }

            Console.WriteLine("Everything is successful. File saved to " + EXCEL_PATH);
        }

        public static void SaveToExcelSpreadsheet(List<AdditionalInfo> data)
        {
            if (File.Exists(EXCEL_PATH))
            {
                File.Delete(EXCEL_PATH);
            }

            Excel.Application oApp = new Excel.Application();

            Excel.Worksheet oSheet;
            Excel.Workbook oBook;

            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);

            long counter = 2;
            oSheet.Cells[1, 1] = "Id";
            oSheet.Cells[1, 2] = "Warranty";
            oSheet.Cells[1, 3] = "Sold Items";
            oSheet.Cells[1, 4] = "description";

            foreach (var item in data)
            {
                oSheet.Cells[counter, 1] = item.Id;
                oSheet.Cells[counter, 2] = item.Warranty;
                oSheet.Cells[counter, 3] = item.SoldItems;
                oSheet.Cells[counter, 4] = item.Description;
                counter++;
            }

            oBook.SaveAs(EXCEL_PATH);
            oBook.Close();
            oApp.Quit();
        }
    }
}
