namespace LoadDataFromXML
{
    using System.Collections.Generic;
    using Data.EF;

    public class MssqlDataImporter : IDataImporter<Models.EF.Order>
    {
        public void ImportOrdersData(ICollection<Models.EF.Order> orders)
        {
            var db = new DatabaseContext();

            foreach (var order in orders)
            {
                db.Orders.Add(order);
            }
        }
    }
}