using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Model.Output
{
    public class OrderProductOutputModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
