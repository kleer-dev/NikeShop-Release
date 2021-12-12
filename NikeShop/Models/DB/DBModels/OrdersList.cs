using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models.DB.DBModels
{
    public class OrdersList
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int CountsOfOrders { get; set; }
        public string SumOfOrders { get; set; }
        public string Nikes { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual User User { get; set; }
    }
}
