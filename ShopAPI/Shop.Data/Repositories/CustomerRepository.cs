using Dapper;
using Microsoft.Extensions.Options;
using Shop.Core.Settings;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shop.Data.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(IOptions<DBSettings> options)
        {
            DbConnection = new SqlConnection(options.Value.ConnectionString);
        }
        #region CRUD
        public CustomerDto GetCustomerById(int id)
        {
            try
            {
                return DbConnection.Get<CustomerDto>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreateCustomer(CustomerDto dto)
        {
            try
            {
                return (int)DbConnection.Insert(dto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateCustomer(CustomerDto dto)
        {
            try
            {
                return DbConnection.Update<CustomerDto>(dto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteCustomer(int id)
        {
            try
            {
                return DbConnection.Delete<CustomerDto>(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
