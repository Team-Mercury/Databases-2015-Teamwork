namespace SqliteAndMySqlToExcel
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    using Excel = Microsoft.Office.Interop.Excel;
    using Models;

    public class Program
    {
        private const string SQLITE_EXCEL_PATH = "D:\\SqliteData.xlsx";
        private const string MYSQL_EXCEL_PATH = "D:\\MysqlData.xlsx";

        public static void Main(string[] args)
        {
            //SaveDataFromSQLiteToExcel();
            SaveDataFromMySqlToExcel();

        }

        public static void SaveDataFromMySqlToExcel()
        {
            using (var db = new LaptopReportsContext())
            {
                var laptopReports = db.Reports.ToList();

                SaveMySqlDataToExcelSpreadsheet(laptopReports);
            }
        }

        public static void SaveDataFromSQLiteToExcel()
        {
            using (var db = new LaptopAddonsContext())
            {
                var additionalData = db.Info.ToList();

                SaveSqliteDataToExcelSpreadsheet(additionalData);
            }

            Console.WriteLine("Everything is successful. File saved to " + SQLITE_EXCEL_PATH);
        }

        public static void SaveMySqlDataToExcelSpreadsheet(List<Report> data)
        {
            if (File.Exists(MYSQL_EXCEL_PATH))
            {
                File.Delete(MYSQL_EXCEL_PATH);
            }

            Excel.Application oApp = new Excel.Application();

            Excel.Worksheet oSheet;
            Excel.Workbook oBook;

            oBook = oApp.Workbooks.Add();
            oSheet = (Excel.Worksheet)oBook.Worksheets.get_Item(1);

            long counter = 2;
            oSheet.Cells[1, 1] = "Id";
            oSheet.Cells[1, 2] = "Name";
            oSheet.Cells[1, 3] = "Profit";

            foreach (var item in data)
            {
                oSheet.Cells[counter, 1] = item.Id;
                oSheet.Cells[counter, 2] = item.Name;
                oSheet.Cells[counter, 3] = item.Profit;
                counter++;
            }

            oBook.SaveAs(MYSQL_EXCEL_PATH);
            oBook.Close();
            oApp.Quit();
            Console.WriteLine("Data from Mysql Safely extracted to " + MYSQL_EXCEL_PATH);
        }

        public static void SaveSqliteDataToExcelSpreadsheet(List<AdditionalInfo> data)
        {
            if (File.Exists(SQLITE_EXCEL_PATH))
            {
                File.Delete(SQLITE_EXCEL_PATH);
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

            oBook.SaveAs(SQLITE_EXCEL_PATH);
            oBook.Close();
            oApp.Quit();
        }
    }
}
