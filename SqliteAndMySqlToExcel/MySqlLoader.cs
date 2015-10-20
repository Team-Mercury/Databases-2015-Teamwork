namespace SqliteAndMySqlToExcel
{
    using System.Collections.Generic;
    using Microsoft.Office.Interop.Excel;
    using Models;

    public class MySqlLoader : AbstractBase
    {
        private readonly string FILE_PATH = "D:\\MysqlData.xlsx";

        public override string FilePath
        {
            get
            {
                return this.FILE_PATH;
            }
        }

        public List<Report> Data { get; set; }

        public override void LoadData(Worksheet oSheet)
        {
            oSheet.Cells[1, 1] = "Id";
            oSheet.Cells[1, 2] = "Name";
            oSheet.Cells[1, 3] = "Profit";

            long counter = 2;

            foreach (var item in Data)
            {
                oSheet.Cells[counter, 1] = item.Id;
                oSheet.Cells[counter, 2] = item.Name;
                oSheet.Cells[counter, 3] = item.Profit;
                counter++;
            }
        }
    }
}
