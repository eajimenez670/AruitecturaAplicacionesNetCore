using Company.Learn.Application.DTO;
using Company.Learn.Cross.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Learn.Application.Interface
{
    public interface ICustomerApplication
    {
        #region Sync Methods
        Response<bool> Insert(CustomerDTO customerDTO);
        Response<bool> Update(CustomerDTO customerDTO);
        Response<bool> Delete(string id);
        Response<CustomerDTO> Get(string id);
        Response<IEnumerable<CustomerDTO>> GetAll();
        #endregion

        #region Async Methods
        Task<Response<bool>> InsertAsync(CustomerDTO customerDTO);
        Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO);
        Task<Response<bool>> DeleteAsync(string id);
        Task<Response<CustomerDTO>> GetAsync(string id);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        #endregion
    }
}
