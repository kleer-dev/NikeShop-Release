using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models
{
    public class CombinePurchaseModel
    {
        public User user { get; set; }
        public Purchase purchase { get; set; }
    }
}
