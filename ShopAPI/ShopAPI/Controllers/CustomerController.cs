using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Business.Manager;
using Shop.Business.Model.Input;
using Shop.Business.Model.Output;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerManager _customerManager;

        public CustomerController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        #region CRUD

        /// <summary>
        /// Get a specific customer by unique id
        /// </summary>
        /// <response code="500"></response>
        /// <returns>Customer</returns>
        [HttpGet("{id}")]
        public ActionResult<CustomerOutputModel> GetCustomer(int id)
        {
            var result = _customerManager.GetCustomerById(id);
            return Ok(result);
        }
        /// <summary>
        /// Add a new customer to database
        /// </summary>
        /// <param name="model">Poduct to be added</param>
        /// <response code="500">Can't create a customer right now</response>
        /// <returns>The number of affected records</returns>
        [HttpPost]
        public ActionResult<int> CreateCustomer([FromBody] CustomerInputModel model)
        {
            var result = _customerManager.CreateCustomer(model);
            return Ok(result);
        }

        /// <summary>
        /// Change any data of customer by customerId
        /// </summary>
        /// <param name="model">Model with Id of customer to update 
        /// and others properties with new values</param>
        /// <returns>The number of affected records</returns>
        [HttpPut]
        public ActionResult<int> UpdateCustomer([FromBody] CustomerInputModel model)
        {
            var result = _customerManager.UpdateCustomer(model);
            return Ok(result);
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id">Id of customer to delete</param>
        /// <returns>The number of affected records</returns>
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteCustomer(int id)
        {
            var result = _customerManager.DeleteCustomer(id);
            return Ok(result);
        }
        #endregion

    }
}
