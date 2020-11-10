using System.Collections.Generic;

namespace Shop.Business.Model.Output
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public string CityId { get; set; }
        public string SellDate { get; set; }
        public int? CustomerId { get; set; }
        public List<ProductOutputModel> Products { get; set; }

    }
}