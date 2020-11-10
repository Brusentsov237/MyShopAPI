using Microsoft.Extensions.Options;
using Shop.Core.Settings;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SqlKata;
using SqlKata.Execution;
using System.Text;
using SqlKata.Compilers;
using Dapper;
using System.Data;
using System.Linq;

namespace Shop.Data.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(IOptions<DBSettings> options)
        {
            DbConnection = new SqlConnection(options.Value.ConnectionString);
        }
        #region CRUD
        public ProductDto GetProductById(int id)
        {
            try
            {
                return DbConnection.Get<ProductDto>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreateProduct(ProductDto product)
        {
            try
            {
                return (int)DbConnection.Insert<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateProduct(ProductDto product)
        {
            try
            {
                return DbConnection.Update<ProductDto>(product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteProduct(int id)
        {
            try
            {
                return DbConnection.Delete<ProductDto>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion
        public int AddProductsToCity(int productId, string color, int quantity, int cityId)
        {
            try
            {
                var result = DbConnection.Query<int>(
                "Product_AddToCity",
                new
                {
                    productId,
                    color,
                    quantity,
                    cityId
                },
                commandType: CommandType.StoredProcedure
                ).SingleOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDto> SearchProduct(ProductSearchDto searchDto)
        {
            try
            {
                var list = new Dictionary<long, ProductDto>();
                DbConnection.Query<ProductDto, CityProductDto, ProductDto>(
                "Search_Product",
                (product, cityProduct) =>
                {
                    ProductDto dto;
                    if (!list.TryGetValue(product.Id.Value, out dto))
                    {
                        dto = product;
                        dto.CityProducts = new List<CityProductDto>() { cityProduct };
                        list.Add(product.Id.Value, dto);
                    }
                    else
                    {
                        dto.CityProducts.Add(cityProduct);
                    }
                    return dto;
                },
                searchDto,
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                ).ToList();
                
                return list.Values.AsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}









//SqlResult sqlResult = compiler.Compile(query);

//var post = db.Query<ProductDto, ManufacturerDto, ProductDto>(sqlResult.Sql, (p, u) => { ...},
//    param: sqlResult.NamedBindings).SingleOrDefault();
////var query = new Query("Product").Where("Id", 1).First();
////SqlResult result = compiler.Compile(query);

////string sql = result.Sql;
////List<object> bindings = result.Bindings;