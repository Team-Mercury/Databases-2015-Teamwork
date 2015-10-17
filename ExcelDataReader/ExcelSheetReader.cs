namespace ExcelReportLoader
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class ExcelSheetReader
    {
        internal const string ConnectionStringFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
        internal const string QueryFormat = "SELECT * FROM [{0}]";
        internal const string DefaultSheetName = "TABLE_NAME";

        public ExcelSheetReader()
        {
        }

        /// <summary>
        /// Read an excel worksheet in an excel file specified by the provided file path and executes the provided action on every read of the DataTableReader(a reader for every row)>
        /// </summary>
        /// <param name="excelFilePath">The absolute path of the that the reader will read from.</param>
        /// <param name="sheetName">The string representation of the name of the sheet to read from.</param>
        /// <param name="action">The action to execute with parameters the excel sheets as an array.</param>
        public void ReadExcelDataWithAction(string excelFilePath, string sheetName, Action<DataTableReader> action)
        {
            var connectionString = string.Format(ConnectionStringFormat, excelFilePath);

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string sheet;

                if (string.IsNullOrWhiteSpace(sheetName))
                {
                    var dataSheet = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheet = dataSheet.Rows[0][DefaultSheetName].ToString();
                }
                else
                {
                    sheet = sheetName.EndsWith("$") ? sheetName : sheetName + "$";
                }

                var oleCommand = new OleDbCommand(QueryFormat.Formatted(sheet), connection);

                using (var adapter = new OleDbDataAdapter(oleCommand))
                {
                    using (var dataSet = new DataSet())
                    {
                        adapter.Fill(dataSet);

                        using (var reader = dataSet.CreateDataReader())
                        {
                            while (reader.Read())
                            {
                                action(reader);
                            }
                        }
                    }
                }

                oleCommand = null;
                connection.Close();
            }
        }
    }
}