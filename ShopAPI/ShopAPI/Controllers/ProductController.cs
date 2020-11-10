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
    public class ProductController : ControllerBase
    {
        ProductManager _productManager;

        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        #region CRUD

        /// <summary>
        /// Get a specific product by unique id
        /// </summary>
        /// <response code="500"></response>
        /// <returns>Product</returns>
        [HttpGet("{id}")]
        public ActionResult<ProductOutputModel> GetProduct(int id)
        {
            var result = _productManager.GetProductById(id);
            return Ok(result);
        }
        /// <summary>
        /// Add a new product to database
        /// </summary>
        /// <param name="model">Poduct to be added</param>
        /// <response code="500">Can't create your product right now</response>
        /// <returns>The number of affected records</returns>
        [HttpPost]
        public ActionResult<int> CreateProduct([FromBody] ProductInputModel model)
        {
            var result = _productManager.CreateProduct(model);
            return Ok(result);
        }

        /// <summary>
        /// Change any data of product by productId
        /// </summary>
        /// <param name="model">Model with Id of product to update 
        /// and others properties with new values</param>
        /// <returns>The number of affected records</returns>
        [HttpPut]
        public ActionResult<int> UpdateProduct([FromBody] ProductInputModel model)
        {
            var result = _productManager.UpdateProduct(model);
            return Ok(result);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">Id of product to delete</param>
        /// <returns>The number of affected records</returns>
        [HttpDelete("{id}")]
        public ActionResult<int> DeleteProduct(int id)
        {
            var result = _productManager.DeleteProduct(id);
            return Ok(result);
        }
        #endregion

        /// <summary>
        /// Get all products in required city or storage
        /// </summary>
        /// <param name="cityId">Id of required city</param>
        /// <returns>All products in required city or storage</returns>
        [HttpGet("city/{cityId}")]
        public ActionResult<List<ProductOutputModel>> GetAllProductByCityId(int cityId)
        {
            var results = _productManager.GetAllProductsByCityId(cityId);
            return Ok(results);
        }


        /// <summary>
        /// Products to be added to city or storage
        /// </summary>
        /// <param name="productId">ProductId to be added to city or storage </param>
        /// <param name="color">Products color</param>
        /// <param name="quantity">Products quantity</param>
        /// <param name="cityId">City or storage </param>
        /// <returns>Quantity of this product in this city or storage</returns>
        [HttpPost("{cityId}")]
        public ActionResult<int> AddProductsToCity(int productId, string color, int quantity, int cityId)
        {
            var newQuantityOfProduct = _productManager.AddProductsToCity(productId,color,quantity,cityId);
            return Ok(newQuantityOfProduct);
        }

        /// <summary>
        /// Search Products
        /// </summary>
        /// <param name="model">Model with search options</param>
        /// <returns>List of products each with quantity and colors for city</returns>
        [HttpPost("search")]
        public ActionResult<List<ProductOutputModel>> GetSearchResult(ProductSearchInputModel model)
        {
            var results = _productManager.FindProduct(model);
            return Ok(results);
        }
    }
}
