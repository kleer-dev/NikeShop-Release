using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models.DB.DBModels
{
    public class Cart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [Required(ErrorMessage = "You must to write your leg size!")]
        [MaxLength(2, ErrorMessage = "Max length = 2")]
        public int Size { get; set; }

        [Required(ErrorMessage = "You must to select sending country")]
        public string Country { get; set; }
        public string Path { get; set; }
        
        public virtual User User { get; set; }
        public virtual Nike Nike { get; set; }
        public virtual OrdersList OrdersList { get; set; }
    }
}
