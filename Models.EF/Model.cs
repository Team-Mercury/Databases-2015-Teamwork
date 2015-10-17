namespace Models.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        public Model()
        {
        }
        
        public int Id { get; set; }

        [StringLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [StringLength(30)]
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
