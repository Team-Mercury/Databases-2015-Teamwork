using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace SqliteAndMySqlToExcel
{
    public abstract class AbstractBase
    {
        public abstract string FilePath { get; }

        public abstract void LoadData(Excel.Worksheet oSheet);
    }
}
