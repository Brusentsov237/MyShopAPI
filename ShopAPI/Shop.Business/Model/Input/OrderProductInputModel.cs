using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Model.Input
{
    public class OrderProductInputModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
