namespace ExcelReportLoader
{
    using System;
    using System.Data;
    using System.IO;

    public static class ExcelReportReadingProvider
    {
        private const string ExcelFileExtensionPattern = "*.xls";

        /// <summary>
        /// Provides the service for iterating over zipped excel reports and performing a given action over each row of every report.
        /// </summary>
        /// <param name="zipLocation">The relative path to the zip archive.</param>
        /// <param name="destination">The relative path to the extraction destination.</param>
        /// <param name="action">THe action to be performed over the rows of every report.</param>
        /// <param name="sheetName">The name of the sheet for every report(default value is "").</param>
        public static void ReadZippedReports(string zipLocation, string destination, Action<DataTableReader> action, string sheetName = "")
        {
            var reader = new ExcelSheetReader();

            var unzipper = new Unzipper(zipLocation);

            unzipper.Extract(destination);

            Directory
                .GetFileSystemEntries(destination, ExcelFileExtensionPattern, SearchOption.AllDirectories)
                .ForEach(path =>
                {
                    reader.ReadExcelDataWithAction(path, sheetName, r => action(r));
                });
        }
    }
}