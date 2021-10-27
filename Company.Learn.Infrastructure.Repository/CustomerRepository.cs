using Company.Learn.Cross.Common;
using Company.Learn.Domain.Entity;
using Company.Learn.Infrastructure.Interface;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Company.Learn.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Fields
        private readonly IConnectionFactory _connectionFactory;
        #endregion

        #region Builders
        public CustomerRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        #endregion

        #region Sync Methods
        public bool Delete(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", id);

                var result = connection.Execute(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public Customer Get(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", id);

                var customer = connection.QuerySingle<Customer>(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return customer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

                var customers = connection.Query<Customer>(
                    sql: query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        public bool Insert(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        public bool Update(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }
        #endregion

        #region Async Methods
        async public Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

                var customers = await connection.QueryAsync<Customer>(
                    sql: query,
                    commandType: CommandType.StoredProcedure
                );
                return customers;
            }
        }

        async public Task<Customer> GetAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", id);

                var customer = await connection.QuerySingleAsync<Customer>(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return customer;
            }
        }

        async public Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        async public Task<bool> UpdateAsync(Customer customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }

        async public Task<bool> DeleteAsync(string id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", id);

                var result = await connection.ExecuteAsync(
                    sql: query,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result > 0;
            }
        }
        #endregion
    }
}
