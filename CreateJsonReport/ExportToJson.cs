namespace CreateJsonReport
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class ExportToJson
    {
        public static void Report(List<MakersLaptops> laptops)
        {
            ParseData(laptops);
        }

        private static void ParseData(List<MakersLaptops> laptops)
        {
            var manufactory = new JsonManufactoryObject();

            foreach (var laptop in laptops)
            {
                if (laptop.MakerId == manufactory.MakerId)
                {
                    continue;
                }
                else
                {
                    manufactory = new JsonManufactoryObject();
                }

                manufactory.MakerId = laptop.MakerId;
                manufactory.MakerName = laptop.MakerName;

                foreach (var item in laptops)
                {
                    if (manufactory.MakerId == item.MakerId)
                    {
                        manufactory.Models.Add(new JsonModelObject
                        {
                            ModelName = item.ModelName,
                            Price = item.Price,
                            Quantity = item.Quantity
                        });
                    }
                    else if (manufactory.MakerId < item.MakerId)
                    {
                        break;
                    }
                }

                string json = JsonConvert.SerializeObject(manufactory, Formatting.Indented);

                SaveInFile(json, manufactory.MakerId);
            }
        }

        private static void SaveInFile(string json, int manufactoryId)
        {
            string path = string.Format("../../Json-Reports/{0}.json", manufactoryId);

            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(json);
            }
        }
    }
}
