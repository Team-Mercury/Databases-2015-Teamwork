namespace CreateJsonReport
{
    using System;
    using System.Data.Entity;

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
