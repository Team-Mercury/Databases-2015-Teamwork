namespace Models.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Maker
    {
        private ICollection<Laptop> laptops;

        public Maker(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Laptops = new HashSet<Laptop>();
        }

        public Maker()
        {
        }

        public int Id { get; set; }

        [StringLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

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
