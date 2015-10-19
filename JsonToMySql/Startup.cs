using JsonToMySql.Models;
using System;

namespace JsonToMySql
{
    class Startup
    {
        static void Main()
        {
            var reports = ImportFromJson.ImportProductsInfo();

            using (var dbContext = new FluentModelContent())
            {

                foreach (var item in reports)
                {
                    dbContext.Add(item);
                }
                 
                dbContext.SaveChanges();
            }

            // Console.WriteLine("The version of the currently executing assembly is: {0}",
            //typeof(Startup).Assembly.GetName().Version);

            // Console.WriteLine("The version of mscorlib.dll is: {0}",
            //     typeof(String).Assembly.GetName().Version);
        }
    }
}
