using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NikeShop.Models.DB.DBModels
{
    public class Purchase : IDisposable
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        [MaxLength(2)]
        public int Size { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cart> Carts { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
