using DocumentFormat.OpenXml.Spreadsheet;
using NikeShop.Models.DB.DBModels;

namespace NikeShop.Models.CombineModels
{
    public class CombineNikeOrderModel
    {
        public Nike Nike { get; set; }
        public OrderCheckModel CheckModel { get; set; }
    }
}