using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    [Table("Order_Product")]
    public class OrderProductDto
    {
        public int? Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
    }
}
