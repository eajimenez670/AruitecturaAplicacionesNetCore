using Company.Learn.Application.DTO;
using Company.Learn.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Company.Learn.Service.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController'
    public class CustomerController : Controller
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController'
    {
        #region Fields
        private readonly ICustomerApplication _customerApplication;
        #endregion

        #region Builders
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.CustomerController(ICustomerApplication)'
        public CustomerController(ICustomerApplication customerApplication)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.CustomerController(ICustomerApplication)'
        {
            _customerApplication = customerApplication;
        }
        #endregion

        #region Sync Methods
        [HttpPost(nameof(CustomerController.Insert))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Insert(CustomerDTO)'
        public IActionResult Insert([FromBody] CustomerDTO customerDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Insert(CustomerDTO)'
        {
            if (customerDTO == null) return BadRequest();
            var response = _customerApplication.Insert(customerDTO);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut(nameof(CustomerController.Update))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Update(CustomerDTO)'
        public IActionResult Update([FromBody] CustomerDTO customerDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Update(CustomerDTO)'
        {
            if (customerDTO == null) return BadRequest();
            var response = _customerApplication.Update(customerDTO);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete(nameof(CustomerController.Delete) + "/{id}")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Delete(string)'
        public IActionResult Delete(string id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Delete(string)'
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var response = _customerApplication.Delete(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet(nameof(CustomerController.Get) + "/{id}")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Get(string)'
        public IActionResult Get(string id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.Get(string)'
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var response = _customerApplication.Get(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet(nameof(CustomerController.GetAll))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAll()'
        public IActionResult GetAll()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAll()'
        {
            var response = _customerApplication.GetAll();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion

        #region Async Methods
        [HttpPost(nameof(CustomerController.InsertAsync))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.InsertAsync(CustomerDTO)'
        async public Task<IActionResult> InsertAsync([FromBody] CustomerDTO customerDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.InsertAsync(CustomerDTO)'
        {
            if (customerDTO == null) return BadRequest();
            var response = await _customerApplication.InsertAsync(customerDTO);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut(nameof(CustomerController.UpdateAsync))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.UpdateAsync(CustomerDTO)'
        async public Task<IActionResult> UpdateAsync([FromBody] CustomerDTO customerDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.UpdateAsync(CustomerDTO)'
        {
            if (customerDTO == null) return BadRequest();
            var response = await _customerApplication.UpdateAsync(customerDTO);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpDelete(nameof(CustomerController.DeleteAsync) + "/{id}")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.DeleteAsync(string)'
        async public Task<IActionResult> DeleteAsync(string id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.DeleteAsync(string)'
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var response = await _customerApplication.DeleteAsync(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet(nameof(CustomerController.GetAsync) + "/{id}")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAsync(string)'
        async public Task<IActionResult> GetAsync(string id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAsync(string)'
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var response = await _customerApplication.GetAsync(id);
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet(nameof(CustomerController.GetAllAsync))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAllAsync()'
        async public Task<IActionResult> GetAllAsync()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CustomerController.GetAllAsync()'
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess) return Ok(response);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
