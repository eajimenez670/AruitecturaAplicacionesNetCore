using Company.Learn.Domain.Entity;
using Company.Learn.Domain.Interface;
using Company.Learn.Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Learn.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        #region fields
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region builders
        public CustomerDomain(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion

        #region Methods Async
        async public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        async public Task<Customer> GetAsync(string id)
        {
            return await _customerRepository.GetAsync(id: id);
        }

        async public Task<bool> InsertAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer: customer);
        }

        async public Task<bool> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer: customer);
        }

        async public Task<bool> DeleteAsync(string id)
        {
            return await _customerRepository.DeleteAsync(id: id);
        }
        #endregion

        #region Methods Sync
        public Customer Get(string id)
        {
            return _customerRepository.Get(id: id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer: customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer: customer);
        }

        public bool Delete(string id)
        {
            return _customerRepository.Delete(id: id);
        }
        #endregion
    }
}
