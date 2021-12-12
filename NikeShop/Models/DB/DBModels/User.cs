using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models.DB.DBModels
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrdersList> OrdersLists { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
