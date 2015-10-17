namespace LoadDataFromXML
{
    public class Program
    {
        public static void Main()
        {
            var productOrders = XmlParser.ParseFile("Orders-per-month.xml");
            XmlProcessor.ProcessToMongo(productOrders);
            XmlProcessor.ProcessToMssql(productOrders);
        }
    }
}
