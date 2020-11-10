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
        private const string _longDateFormat = "dd.MM.yyyy HH:mm:ss";
        public MappingProfile()
        {
            CreateMap<ProductInputModel, ProductDto>();
            CreateMap<ProductDto, ProductOutputModel>();

            CreateMap<CityProductDto, CityProductOutputModel>();

            CreateMap<ProductSearchInputModel, ProductSearchDto>();

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

            //CreateMap<LeadDto, LeadOutputModel>()
            //    .ForPath(dest => dest.Birthday, o => o.MapFrom(src => src.Birthday.ToString(_shortDateFormat)))
            //    .ForPath(dest => dest.RegistrationDate, o => o.MapFrom(src => src.RegistrationDate.ToString(_longDateFormat)))
            //    .ForPath(dest => dest.LastUpdateDate, o => o.MapFrom(src => src.LastUpdateDate.ToString(_longDateFormat)));


            //CreateMap<LeadDto, AuthOutputModel>()
            //    .ForPath(dest => dest.Role, o => o.MapFrom(src => src.Role.Name));

            //CreateMap<SearchInputModel, SearchDto>()
            //    .ForPath(dest => dest.BirthdayFrom, o => o.MapFrom(src => src.BirthdayFrom != null ? (DateTime?)DateTime.ParseExact(src.BirthdayFrom, _shortDateFormat, CultureInfo.InvariantCulture) : null))
            //    .ForPath(dest => dest.BirthdayTo, o => o.MapFrom(src => src.BirthdayTo != null ? (DateTime?)DateTime.ParseExact(src.BirthdayTo, _shortDateFormat, CultureInfo.InvariantCulture) : null))
            //    .ForPath(dest => dest.RegistrationDateFrom, o => o.MapFrom(src => src.RegistrationDateFrom != null ? (DateTime?)DateTime.ParseExact(src.RegistrationDateFrom, _shortDateFormat, CultureInfo.InvariantCulture) : null))
            //    .ForPath(dest => dest.RegistrationDateTo, o => o.MapFrom(src => src.RegistrationDateTo != null ? (DateTime?)DateTime.ParseExact(src.RegistrationDateTo, _shortDateFormat, CultureInfo.InvariantCulture) : null))
            //    .ForPath(dest => dest.Role, o => o.MapFrom(src => src.RoleId != null ? new RoleDto() { Id = (int)src.RoleId } : null))
            //    .ForPath(dest => dest.City, o => o.MapFrom(src => src.CityId != null ? new CityDto() { Id = (int)src.CityId } : null));

            //CreateMap<AccountInputModel, AccountDto>();

            //CreateMap<AccountDto, AccountOutputModel>();

        }
    }
}
