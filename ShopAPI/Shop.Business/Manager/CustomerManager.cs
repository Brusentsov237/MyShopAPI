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
    public class CustomerManager
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerManager(CustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        #region CRUD
        public int CreateCustomer(CustomerInputModel customer)
        {
            var dto = _mapper.Map<CustomerDto>(customer);
            return _customerRepository.CreateCustomer(dto);
        }
        public int UpdateCustomer(CustomerInputModel customer)
        {
            var dto = _mapper.Map<CustomerDto>(customer);
            return _customerRepository.UpdateCustomer(dto);
        }
        public CustomerOutputModel GetCustomerById(int id)
        {
            var result = _customerRepository.GetCustomerById(id);
            var output = _mapper.Map<CustomerOutputModel>(result);
            return output;
        }
        public int DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
        #endregion
        
        public object FindCustomer(CustomerSearchInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
