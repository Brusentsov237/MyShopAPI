using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    public class CityProductDto
    {
        public int? Id { get; set; }
        public int CityId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
