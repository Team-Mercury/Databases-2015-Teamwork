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
            var maker = new MakersProfit();

            foreach (var laptop in laptops)
            {
                if (laptop.MakerId == maker.MakerId)
                {
                    continue;
                }
                else
                {
                    maker = new MakersProfit();
                }

                maker.MakerId = laptop.MakerId;
                maker.MakerName = laptop.MakerName;

                decimal profit = 0;

                foreach (var item in laptops)
                {
                    if (maker.MakerId == item.MakerId)
                    {
                        profit += item.Price * item.Quantity;
                    }
                    else if (maker.MakerId < item.MakerId)
                    {
                        break;
                    }
                }

                maker.Profit = profit;

                string json = JsonConvert.SerializeObject(maker, Formatting.Indented);

                SaveInFile(json, maker.MakerId);
            }
        }

        private static void SaveInFile(string json, int manufactoryId)
        {
            string path = string.Format("../../../Json-Reports/{0}.json", manufactoryId);

            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(json);
            }
        }
    }
}
