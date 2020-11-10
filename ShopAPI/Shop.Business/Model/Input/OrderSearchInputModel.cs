namespace Shop.Business.Model.Input
{
    public class OrderSearchInputModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public string SellDateFrom { get; set; } = "01.01.2000";
        public string SellDateTo { get; set; } = "01.01.3000";
        public int? CityId { get; set; }
    }
}