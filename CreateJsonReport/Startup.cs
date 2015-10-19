namespace CreateJsonReport
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var laptops = ImportFromSqlServer.GetData();
            ExportToJson.Report(laptops);
            Console.WriteLine("DONE!!");
        }
    }
}
