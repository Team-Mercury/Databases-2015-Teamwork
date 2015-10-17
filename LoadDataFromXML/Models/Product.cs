namespace LoadDataFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    public class Product
    {
        [XmlAttribute]
        public string ModelName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
