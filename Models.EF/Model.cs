namespace Models.EF
{
    using System.Collections.Generic;

    public class Model
    {
        private ICollection<Laptop> laptops;

        public Model(string name, string cpu, int ram, int hdd)
        {
            this.Name = name;
            this.CPU = cpu;
            this.RAM = ram;
            this.HDD = hdd;
            this.Laptops = new HashSet<Laptop>();
        }
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string CPU { get; set; }

        public int RAM { get; set; }

        public int HDD { get; set; }

        public virtual ICollection<Laptop> Laptops
        {
            get
            {
                return this.laptops;
            }

            set
            {
                this.laptops = value;
            }
        }
    }
}
