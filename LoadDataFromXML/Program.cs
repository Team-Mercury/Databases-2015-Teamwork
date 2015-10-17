namespace LoadDataFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var productOrders = XmlParser.ParseFile("Orders-per-month.xml");
            XmlProcessor.ProcessToMongo(productOrders);
        }
    }
}
