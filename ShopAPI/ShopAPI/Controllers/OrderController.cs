using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Business.Manager;
using Shop.Business.Model.Input;
using Shop.Business.Model.Output;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderManager _orderManager;

        public OrderController(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        #region CRUD

        /// <summary>
        /// Get a specific order by unique id
        /// </summary>
        /// <response code="500"></response>
        /// <returns>Order</returns>
        [HttpGet("{id}")]
        public ActionResult<OrderOutputModel> GetOrder(int id)
        {
            var result = _orderManager.GetOrderById(id);
            return Ok(result);
        }
        /// <summary>
        /// Add a new order to database
        /// </summary>
        /// <param name="model">Poduct to be added</param>
        /// <response code="500">Can't create your order right now</response>
        /// <returns>The number of affected records</returns>
        [HttpPost]
        public ActionResult<int> CreateOrder([FromBody] OrderInputModel model)
        {
            int result = _orderManager.CreateOrder(model);
            return Ok(result);
        }
        #endregion

        [HttpGet("customer/{customerId}")]
        public ActionResult<List<OrderOutputModel>> GetAllOrdersByCustomerId(int customerId)
        {
            var results = _orderManager.GetAllOrdersByCustomerId(customerId);
            return Ok(results);
        }

        [HttpPost("search")]
        public ActionResult<List<OrderOutputModel>> GetSearchResult(OrderSearchInputModel model)
        {
            var results = _orderManager.FindOrder(model);
            return Ok(results);
        }
    }
}
