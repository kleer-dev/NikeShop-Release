using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models.DB.DBModels
{
    public class Nike
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
