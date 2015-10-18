namespace CreateJsonReport
{
    using System.Collections.Generic;

    public class Manufactory
    {
        public Manufactory()
        {
            this.Models = new List<Mod>();
        }

        public int MakerId { get; set; }

        public string MakerName { get; set; }

        public List<Mod> Models { get; set; }

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
