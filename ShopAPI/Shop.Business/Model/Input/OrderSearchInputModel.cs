namespace Shop.Business.Model.Input
{
    public class OrderSearchInputModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public string SellDateFrom { get; set; }
        public string SellDateTo { get; set; }
        public int? CityId { get; set; }
    }
}