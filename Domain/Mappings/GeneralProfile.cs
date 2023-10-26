using AutoMapper;
using DTO.EmployeeDTO;
using DTO.FormDTO;
using DTO.LoginDTO;
using DTO.RoleDTO;
using DTO.UserDTO;
using Entities.Model;


namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<LoginDTO, Employee>().ReverseMap();
            CreateMap<EmployeeRoleDTO, EmployeeRole>().ReverseMap();
            CreateMap<LoginCredentialsDTO, Employee>().ReverseMap();
            CreateMap<FormDTO, Form>().ReverseMap();
            CreateMap<RoleDTO1, Role>().ReverseMap();
        }
    }
}
