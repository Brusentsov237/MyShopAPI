namespace Shop.Business.Model.Input
{
    public class ProductSearchInputModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }

        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }

        public string Color { get; set; }
        public int? CityId { get; set; }

        public string Freezer { get; set; }
        public bool? HasNoFrost { get; set; }
        public bool? HasFreshZone { get; set; }
        public bool? HasSafetyShutDown { get; set; }
        public bool? HasSpit { get; set; }
        public bool? HasMicrowaveMod { get; set; }
        public string SwitchType { get; set; }
        public int? SpeedModQuantity { get; set; }
        public string VentingMod { get; set; }
        public int? MaximumProductivity { get; set; }
        public int? ProgramQuantity { get; set; }
        public string PanelMaterial { get; set; }
        public string PanelType { get; set; }
    }
}