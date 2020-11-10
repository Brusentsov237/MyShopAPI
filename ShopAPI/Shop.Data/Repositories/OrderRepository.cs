using Dapper;
using Microsoft.Extensions.Options;
using Shop.Core.Settings;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Shop.Data.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(IOptions<DBSettings> options)
        {
            DbConnection = new SqlConnection(options.Value.ConnectionString);
        }
        #region CRUD
        public OrderDto GetOrderById(int id)
        {
            try
            {
                var list = new Dictionary<long, OrderDto>();
                var lead = DbConnection.Query<OrderDto, OrderProductDto, OrderDto>(
                "Order_Select",
                (order, product) =>
                {
                    OrderDto dto;
                    if (!list.TryGetValue(order.Id.Value, out dto))
                    {
                        dto = order;
                        dto.Products = new List<OrderProductDto>() { product };
                        list.Add(order.Id.Value, dto);
                    }
                    else
                    {
                        dto.Products.Add(product);
                    }
                    return dto;
                },
                new { id },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure
                ).ToList();
                return lead[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<OrderSearchDto> SearchOrder(OrderSearchDto searchDto)
        {
            throw new NotImplementedException();
        }

        public int CreateOrder(OrderDto order)
        {
            try
            {
                var orderId = (int)DbConnection.Insert(order);
                foreach (OrderProductDto product in order.Products)
                {
                    product.OrderId = orderId;
                    DbConnection.Insert(product);
                }
                return orderId; 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
