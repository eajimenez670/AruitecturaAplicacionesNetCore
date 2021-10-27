using Company.Learn.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Learn.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region Sync Methods
        bool Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(string id);
        Customer Get(string id);
        IEnumerable<Customer> GetAll();
        #endregion

        #region Async Methods
        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string id);
        Task<Customer> GetAsync(string id);
        Task<IEnumerable<Customer>> GetAllAsync();
        #endregion
    }
}
