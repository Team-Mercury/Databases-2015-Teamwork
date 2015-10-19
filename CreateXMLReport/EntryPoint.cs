namespace CreateXMLReport
{
    using System;
    using System.Linq;
    using System.Xml;
    using Data.EF;

    public class EntryPoint
    {
        public static void Main()
        {
            Console.WriteLine("Extracting information from database and saving it to xml report...");

            using (var db = new DatabaseContext())
            {
                // Query to sql server. Join three tables - Models, Laptops and Makers to take whole information about laptop. 
                var laptops =
                    from model in db.Models
                    join laptop in db.Laptops
                    on model.Id equals laptop.Id
                    join maker in db.Makers
                    on laptop.Id equals maker.Id
                    select new
                    {
                        MakerName = maker.Name,
                        ModelName = model.Name,
                        Cpu = model.CPU,
                        Hdd = model.HDD,
                        Ram = model.RAM
                    };

                // Create class types elements - high, medium, low
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement classTypes = doc.CreateElement("classTypes");
                doc.AppendChild(classTypes);

                XmlElement highClass = doc.CreateElement("highClass");
                classTypes.AppendChild(highClass);

                XmlElement mediumClass = doc.CreateElement("mediumClass");
                classTypes.AppendChild(mediumClass);

                XmlElement lowClass = doc.CreateElement("lowClass");
                classTypes.AppendChild(lowClass);


                foreach (var laptop in laptops)
                {
                    // Create laptop elements
                    XmlElement laptopItem = doc.CreateElement("laptop");

                    XmlElement maker = doc.CreateElement("maker");
                    XmlText makerName = doc.CreateTextNode(laptop.MakerName);
                    maker.AppendChild(makerName);
                    laptopItem.AppendChild(maker);

                    XmlElement model = doc.CreateElement("model");
                    XmlText modelName = doc.CreateTextNode(laptop.ModelName);
                    model.AppendChild(modelName);
                    laptopItem.AppendChild(model);

                    XmlElement parameters = doc.CreateElement("parameters");
                    laptopItem.AppendChild(parameters);

                    XmlElement cpu = doc.CreateElement("cpu");
                    XmlText cpuText = doc.CreateTextNode(laptop.Cpu);
                    cpu.AppendChild(cpuText);
                    parameters.AppendChild(cpu);

                    XmlElement ram = doc.CreateElement("ram");
                    XmlText ramText = doc.CreateTextNode(laptop.Ram.ToString());
                    ram.AppendChild(ramText);
                    parameters.AppendChild(ram);

                    XmlElement hdd = doc.CreateElement("hdd");
                    XmlText hddText = doc.CreateTextNode(laptop.Hdd.ToString());
                    hdd.AppendChild(hddText);
                    parameters.AppendChild(hdd);

                    if (laptop.Cpu.Contains("i7"))
                    {
                        highClass.AppendChild(laptopItem);

                    }
                    else if (laptop.Cpu.Contains("i5"))
                    {
                        mediumClass.AppendChild(laptopItem);
                    }
                    else if (laptop.Cpu.Contains("i3"))
                    {
                        lowClass.AppendChild(laptopItem);
                    }
                }

                doc.Save("../../classTypesOfLaptopReport.xml");
            }
        }
    }
}
