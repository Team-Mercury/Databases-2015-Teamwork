using JsonToMySql.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JsonToMySql
{
    class ImportFromJson
    {
        public static List<MakersProfit> ImportProductsInfo()
        {
            var path = "../../../Json-Reports";
            var files = Directory.GetFiles(path);

            string jsonReport;

            var copy = new List<MakersProfit>();

            for (int i = 0; i < files.Length; i++)
            {
                jsonReport = File.ReadAllText(files[i]);
                copy.Add(JsonConvert.DeserializeObject<MakersProfit>(jsonReport));
            }

            return copy;
        }
    }
}
