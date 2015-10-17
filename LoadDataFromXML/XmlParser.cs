namespace LoadDataFromXML
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class XmlParser
    {
        public static IEnumerable<Product> ParseFile(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("orders-per-month-by-model"));
            IEnumerable<Product> productOrders;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                productOrders = (IEnumerable<Product>)serializer.Deserialize(fs);
            }

            return productOrders;
        }
    }
}
