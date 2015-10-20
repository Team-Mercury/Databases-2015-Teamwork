namespace SqliteAndMySqlToExcel
{
    using System.Collections.Generic;
    using Microsoft.Office.Interop.Excel;
    using Models;

    public class SqliteLoader : AbstractBase
    {
        private readonly string FILE_PATH = "D:\\SqliteData.xlsx";

        public override string FilePath
        {
            get
            {
                return this.FILE_PATH;
            }
        }

        public List<AdditionalInfo> Data { get; set; }

        public override void LoadData(Worksheet oSheet)
        {
            long counter = 2;
            oSheet.Cells[1, 1] = "Id";
            oSheet.Cells[1, 2] = "Warranty";
            oSheet.Cells[1, 3] = "Sold Items";
            oSheet.Cells[1, 4] = "description";

            foreach (var item in Data)
            {
                oSheet.Cells[counter, 1] = item.Id;
                oSheet.Cells[counter, 2] = item.Warranty;
                oSheet.Cells[counter, 3] = item.SoldItems;
                oSheet.Cells[counter, 4] = item.Description;
                counter++;
            }
        }
    }
}
