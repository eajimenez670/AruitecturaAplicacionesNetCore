using AutoMapper;
using Company.Learn.Application.DTO;
using Company.Learn.Domain.Entity;

namespace Company.Learn.Cross.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
