using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClosedXML.Excel;
using NikeShop.Models;
using NikeShop.Models.DB.DBModels;

namespace NikeShop.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult ExportToExcel()
        {
            var userid = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = ApplicationContext.db.Users.Where(p => p.ID == userid).FirstOrDefault();

            var purchases = ApplicationContext.db.Purchases.Where(p => p.User == user).ToList();

            using (XLWorkbook workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                var worksheet = workbook.Worksheets.Add("purchases");
                var currentRow = 1;
                
                worksheet.Cell(currentRow, 1).Value = "Date";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow,3).Value = "Price";
                worksheet.Cell(currentRow,4).Value = "Sending country";
                worksheet.Cell(currentRow,5).Value = "Size";

                foreach (var item in purchases)
                {
                    currentRow++;
                    
                    worksheet.Cell(currentRow, 1).Value = item.Date.ToString();
                    worksheet.Cell(currentRow, 2).Value = item.Name;
                    worksheet.Cell(currentRow,3).Value = item.Price;
                    worksheet.Cell(currentRow,4).Value = item.Country;
                    worksheet.Cell(currentRow,5).Value = item.Size;
                }
                
                var rngTable = worksheet.Range("A1:E" + worksheet.Rows().Count());
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;

                worksheet.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Purchases.xlsx");
                }
            }

            return RedirectToAction("UserAccount", "UserPage");
        }
    }
}
