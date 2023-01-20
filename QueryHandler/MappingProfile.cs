using AutoMapper;
using DataEntity;
using DomainModel;
using DomainModel.Department;
using DomainModel.User;

namespace QueryHandler
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeModel, EmployeeDTO>().ReverseMap();
            CreateMap<DepartmentModel, DepartmentDTO>().ReverseMap();
            CreateMap<UserModel, UserDTO>().ReverseMap();
        }
    }
}
