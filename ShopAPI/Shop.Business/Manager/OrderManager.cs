using AutoMapper;
using Shop.Business.Model.Input;
using Shop.Business.Model.Output;
using Shop.Data.Dto;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Manager
{
    public class OrderManager 
    {
        private readonly OrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderManager(OrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #region CRUD
        public int CreateOrder(OrderInputModel order)
        {
            var dto = _mapper.Map<OrderDto>(order);
            return _orderRepository.CreateOrder(dto);
        }
        
        public OrderOutputModel GetOrderById(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            var output = _mapper.Map<OrderOutputModel>(order);
            return output;
        }
       
        #endregion

        public List<OrderOutputModel> FindOrder(OrderSearchInputModel model)
        {
            var searchDto = _mapper.Map<OrderSearchDto>(model);
            var orders = _orderRepository.SearchOrder(searchDto);
            var output = _mapper.Map<List<OrderOutputModel>>(orders);
            return output;
        }

        public List<OrderOutputModel> GetAllOrdersByCustomerId(int customerId)
        {
            var searchDto = new OrderSearchDto { CustomerId = customerId };
            var orders = _orderRepository.SearchOrder(searchDto);
            var output = _mapper.Map<List<OrderOutputModel>>(orders);
            return output;
        }
    }
}
