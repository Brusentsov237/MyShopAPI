using System.Collections.Generic;

namespace Shop.Business.Model.Input
{
    public class OrderInputModel
    {
        public int? CustomerId { get; set; }
        public string SellDate { get; set; }
        public int CityId { get; set; }
        public List<OrderProductInputModel> Products { get; set; }
    }
}