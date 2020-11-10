using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    public class OrderSearchDto
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime SellDateFrom { get; set; }
        public DateTime SellDateTo { get; set; }
        public int? CityId { get; set; }
    }
}
