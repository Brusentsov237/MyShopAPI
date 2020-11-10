using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Model.Output
{
    public class CityProductOutputModel
    {
        public int? Id { get; set; }
        public int CityId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
