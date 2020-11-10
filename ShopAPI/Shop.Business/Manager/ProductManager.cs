using AutoMapper;
using Shop.Business.Model.Input;
using Shop.Business.Model.Output;
using Shop.Data.Dto;
using Shop.Data.Enums;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Manager
{
    public class ProductManager
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        #region CRUD
        public int CreateProduct(ProductInputModel product)
        {
            var dto = _mapper.Map<ProductDto>(product);
            return _productRepository.CreateProduct(dto);
        }
        public int UpdateProduct(ProductInputModel product)
        {
            var dto = _mapper.Map<ProductDto>(product);
            return _productRepository.UpdateProduct(dto);
        }
        public ProductOutputModel GetProductById(int id)
        {
            var result = _productRepository.GetProductById(id);
            var output = _mapper.Map<ProductOutputModel>(result);
            return output;
        }
        public int DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
        #endregion

        public List<ProductOutputModel> FindProduct(ProductSearchInputModel model)
        {
            var searchDto = _mapper.Map<ProductSearchDto>(model);
            var products = _productRepository.SearchProduct(searchDto);

            List<ProductOutputModel> output;
            if (model.CategoryId != null)
            {
                var filtredProducts = FilterProductsByCategoryId((int)model.CategoryId, products);
                output = _mapper.Map<List<ProductOutputModel>>(filtredProducts);
            }
            else output = _mapper.Map<List<ProductOutputModel>>(products);
            return output;
        }
        public List<ProductOutputModel> GetAllProductsByCityId(int cityId)
        {
            var searchDto = new ProductSearchDto { CityId = cityId };

            var products = _productRepository.SearchProduct(searchDto);
            var output = _mapper.Map<List<ProductOutputModel>>(products);
            return output;
        }

        public int AddProductsToCity(int productId, string color, int quantity, int cityId)
        {
            return _productRepository.AddProductsToCity(productId, color, quantity, cityId);
        }
        private List<ProductDto> FilterProductsByCategoryId(int categoryId, List<ProductDto> products)
        {
            var result = new List<ProductDto>();
            foreach (var product in products)
            {
                switch (categoryId)
                {
                    case (int)Category.Fridge:
                        if (product.HasFreshZone != null && product.HasNoFrost != null)
                            result.Add(product);
                        break;

                    case (int)Category.Stove:
                        if (product.SwitchType != null && product.HasSafetyShutDown != null)
                            result.Add(product);
                        break;

                    case (int)Category.VacuumCleaner:
                        if (product.VentingMod == null && product.SpeedModQuantity != null && product.MaximumProductivity != null)
                            result.Add(product);
                        break;

                    case (int)Category.RobotCleaner:
                        if (product.ProgramQuantity != null && product.MaximumProductivity != null)
                            result.Add(product);
                        break;

                    case (int)Category.KitchenHood:
                        if (product.VentingMod != null && product.SpeedModQuantity != null && product.MaximumProductivity != null)
                            result.Add(product);
                        break;

                    case (int)Category.DishWasher:
                        if (product.ProgramQuantity != null && product.MaximumProductivity == null)
                            result.Add(product);
                        break;

                    case (int)Category.Hob:
                        if(product.PanelMaterial != null && product.PanelType != null)
                            result.Add(product);
                        break;

                    case (int)Category.Oven:
                        if (product.HasSpit != null && product.HasMicrowaveMod != null)
                            result.Add(product);
                        break;
                   
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
