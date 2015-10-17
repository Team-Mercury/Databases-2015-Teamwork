namespace ExcelReportLoader
{
    using Ionic.Zip;

    public class Unzipper
    {
        public Unzipper()
        {
        }

        public Unzipper(string zipFilePath, ExtractExistingFileAction extractionStratedy = ExtractExistingFileAction.OverwriteSilently)
        {
            this.Path = zipFilePath;
            this.ExtractionStrategy = extractionStratedy;
        }

        public string Path { get; set; }

        public ExtractExistingFileAction ExtractionStrategy { get; set; }

        public void Extract(string destinationFolderPath)
        {
            using (var zip = new ZipFile(this.Path))
            {
                zip.ExtractAll(destinationFolderPath, this.ExtractionStrategy);
            }
        }

        public ZipInputStream Extract(ZipInputStream extractionStream)
        {
            using (var zip = new ZipFile(this.Path))
            {
                zip.ForEach(x => x.Extract(extractionStream));
            }

            return extractionStream;
        }
    }
}