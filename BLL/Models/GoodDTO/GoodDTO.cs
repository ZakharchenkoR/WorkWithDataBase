using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.GoodDTO
{
   public class GoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
    }
}
