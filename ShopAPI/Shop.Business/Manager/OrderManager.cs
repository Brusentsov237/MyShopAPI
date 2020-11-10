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
            var result = _orderRepository.GetOrderById(id);
            var output = _mapper.Map<OrderOutputModel>(result);
            return output;
        }
       
        #endregion

        public object FindOrder(OrderSearchInputModel model)
        {
            throw new NotImplementedException();
        }
       
        public List<OrderOutputModel> GetAllOrdersByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
