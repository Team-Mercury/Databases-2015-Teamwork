namespace CreateJsonReport
{
    using Data.EF;
    using System.Linq;
    using System.Collections.Generic;

    public class ImportFromSqlServer
    {
        public static List<MakersLaptops> GetData()
        {
            using (var db = new DatabaseContext())
            {
                var laptops = db.Laptops
                  .Select(l => new MakersLaptops
                  {
                      MakerId = l.MakerID,
                      MakerName = l.Maker.Name,
                      ModelName = l.Model.Name,
                      Price = l.Price,
                      Quantity = l.Quantity
                  })
                  .OrderBy(id => id.MakerId)
                  .ToList();

                return laptops;

            }
        }
    }
}
