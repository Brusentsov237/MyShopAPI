using AutoMapper;
using Shop.Business.Model.Input;
using Shop.Business.Model.Output;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Business.Config
{
    public class MappingProfile : Profile
    {
        private const string _shortDateFormat = "dd.MM.yyyy";
        public MappingProfile()
        {
            CreateMap<ProductInputModel, ProductDto>();
            CreateMap<ProductDto, ProductOutputModel>();

            CreateMap<ProductSearchInputModel, ProductSearchDto>();

            CreateMap<CityProductDto, CityProductOutputModel>();


            CreateMap<CustomerInputModel, CustomerDto>();
            CreateMap<CustomerDto, CustomerOutputModel>();

            CreateMap<OrderInputModel, OrderDto>()
                .ForPath(dest => dest.SellDate, o => o.MapFrom(src => src.SellDate != null ? (DateTime?)DateTime.ParseExact(src.SellDate, _shortDateFormat, CultureInfo.InvariantCulture) : null))
                ;
            CreateMap<OrderDto, OrderOutputModel>()
                .ForPath(dest => dest.SellDate, o => o.MapFrom(src => src.SellDate.ToString(_shortDateFormat)))
                ;

            CreateMap<OrderProductInputModel, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProductOutputModel>();

            CreateMap<OrderSearchInputModel, OrderSearchDto>()
                .ForPath(dest => dest.SellDateFrom, o => o.MapFrom(src => src.SellDateFrom != null ? (DateTime?)DateTime.ParseExact(src.SellDateFrom, _shortDateFormat, CultureInfo.InvariantCulture) : null))
                .ForPath(dest => dest.SellDateTo, o => o.MapFrom(src => src.SellDateTo != null ? (DateTime?)DateTime.ParseExact(src.SellDateTo, _shortDateFormat, CultureInfo.InvariantCulture) : null))
                ;
        }
    }
}
