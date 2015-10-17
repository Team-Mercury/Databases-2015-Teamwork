namespace LoadDataFromXML
{
    using System.Xml.Serialization;

    public class Order
    {
        [XmlAttribute]
        public string Month { get; set; }

        [XmlText]
        public int Count { get; set; }
    }
}
