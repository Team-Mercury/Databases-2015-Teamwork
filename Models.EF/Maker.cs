namespace Models.EF
{
    using System.Collections.Generic;

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

        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

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
