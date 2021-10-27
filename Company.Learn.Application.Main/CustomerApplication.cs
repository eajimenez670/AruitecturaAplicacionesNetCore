using AutoMapper;
using Company.Learn.Application.DTO;
using Company.Learn.Application.Interface;
using Company.Learn.Cross.Common;
using Company.Learn.Domain.Entity;
using Company.Learn.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.Learn.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly ICustomerDomain _customerDomain;
        private readonly IAppLogger<CustomerApplication> _logger;
        #endregion

        #region Builders
        public CustomerApplication(IMapper mapper, ICustomerDomain customerDomain,
            IAppLogger<CustomerApplication> logger)
        {
            _mapper = mapper;
            _customerDomain = customerDomain;
            _logger = logger;
        }
        #endregion

        #region Methods
        #region Sync Methods
        public Response<bool> Delete(string id)
        {
            var response = new Response<bool>();
            try
            {
                var result = _customerDomain.Delete(id: id);
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Elimación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<CustomerDTO> Get(string id)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var result = _customerDomain.Get(id: id);
                if (result != null)
                {
                    response.Data = _mapper.Map<CustomerDTO>(result);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var result = _customerDomain.GetAll();
                if (result != null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(result);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                    _logger.LogInformation("Consulta Exitosa!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }

            return response;
        }

        public Response<bool> Insert(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var result = _customerDomain.Insert(customer: _mapper.Map<Customer>(customerDTO));
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Inserción Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public Response<bool> Update(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var result = _customerDomain.Update(customer: _mapper.Map<Customer>(customerDTO));
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        #endregion

        #region Async Methods
        async public Task<Response<bool>> DeleteAsync(string id)
        {
            var response = new Response<bool>();
            try
            {
                var result = await _customerDomain.DeleteAsync(id: id);
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Elimación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        async public Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var result = await _customerDomain.GetAllAsync();
                if (result != null)
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(result);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        async public Task<Response<CustomerDTO>> GetAsync(string id)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var result = await _customerDomain.GetAsync(id: id);
                if (result != null)
                {
                    response.Data = _mapper.Map<CustomerDTO>(result);
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        async public Task<Response<bool>> InsertAsync(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var result = await _customerDomain.InsertAsync(
                    customer: _mapper.Map<Customer>(customerDTO)
                );
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Inserción Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        async public Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO)
        {
            var response = new Response<bool>();
            try
            {
                var result = await _customerDomain.UpdateAsync(
                    customer: _mapper.Map<Customer>(customerDTO)
                );
                if (result)
                {
                    response.Data = result;
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
        #endregion
        #endregion
    }
}
