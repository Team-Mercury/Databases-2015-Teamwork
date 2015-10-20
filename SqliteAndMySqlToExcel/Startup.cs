namespace SqliteAndMySqlToExcel
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    using Excel = Microsoft.Office.Interop.Excel;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Reading from MySqlDatabase if imported of course.");
            var MySqlLoader = new MySqlLoader();
            MySqlLoader.Data = LoadDataFromMySql();
            SaveDataToExcelSpreadsheet(MySqlLoader);

            Console.WriteLine("Reading from Sqlite Database.");
            var sqliteLoader = new SqliteLoader();
            sqliteLoader.Data = LoadDataFromSQLite();
            SaveDataToExcelSpreadsheet(sqliteLoader);
        }

        public static List<Report> LoadDataFromMySql()
        {
            using (var db = new LaptopReportsContext())
            {
                var laptopReports = db.Reports.ToList();

                return laptopReports;
            }
        }

        public static List<AdditionalInfo> LoadDataFromSQLite()
        {
            using (var db = new LaptopAddonsContext())
            {
                var additionalData = db.Info.ToList();

                return additionalData;
            }
        }

        public static void SaveDataToExcelSpreadsheet(AbstractBase loader)
        {
            if (File.Exists(loader.FilePath))
            {
                File.Delete(loader.FilePath);
            }

            Excel.Application oApp = new Excel.Application();

            Excel.Worksheet oSheet;
            Excel.Workbook oBook;

            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);

            loader.LoadData(oSheet);

            oBook.SaveAs(loader.FilePath);
            oBook.Close();
            oApp.Quit();
            Console.WriteLine("Data Safely extracted to " + loader.FilePath);
        }
    }
}
