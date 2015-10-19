namespace CreateJsonReport
{
    using System.Collections.Generic;

    public class JsonManufactoryObject
    {
        public JsonManufactoryObject()
        {
            this.Models = new List<JsonModelObject>();
        }

        public int MakerId { get; set; }

        public string MakerName { get; set; }

        public List<JsonModelObject> Models { get; set; }

        public decimal Profit
        {
            get
            {
                decimal sum = 0;
                foreach (var model in this.Models)
                {
                    sum += model.Quantity * model.Price;
                }

                return sum;
            }
        }
    }
}
