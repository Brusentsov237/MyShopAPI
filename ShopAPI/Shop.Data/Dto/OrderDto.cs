using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    [Table("Order")]
    public class OrderDto
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime SellDate { get; set; }
        public int CityId { get; set; }

        [IgnoreInsert]
        public List<OrderProductDto> Products { get; set; }
    }
}
