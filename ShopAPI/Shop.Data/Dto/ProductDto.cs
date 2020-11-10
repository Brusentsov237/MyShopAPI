using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    [Table("Product")]
    public class ProductDto
    {
        [Key]
        public int? Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        //public ManufacturerDto Manufacturer { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Xrange { get; set; }
        public decimal Yrange { get; set; }
        public decimal Zrange { get; set; }
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
        [IgnoreInsert]
        public List<CityProductDto> CityProducts { get; set; }
    }
}
