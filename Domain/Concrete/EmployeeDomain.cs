using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.EmployeeDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;


namespace Domain.Concrete
{
    internal class EmployeeDomain : DomainBase, IEmployeeDomain
    {
        public EmployeeDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IEmployeeRepository employeeRepository => _unitOfWork.GetRepository<IEmployeeRepository>();

        public IList<EmployeeDTO> GetAllUsers()
        {
            IEnumerable<Employee> user = employeeRepository.GetAll();
            var test = _mapper.Map<IList<EmployeeDTO>>(user);
            return test;
        }

        public EmployeeDTO GetUserById(Guid id)
        {
            Employee user = employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDTO>(user);
        }

        public EmployeeDTO Create(EmployeeDTO employee)
        {

            Employee user = _mapper.Map<Employee>(employee);
            user.EmployeeId = Guid.NewGuid();
            
            foreach (var item in employee.RoleId)
            {

                EmployeeRole x = new EmployeeRole();
                x.EmployeeId = user.EmployeeId;
                x.RoleId = item;
                user.EmployeeRoles.Add(x);
            }

            employeeRepository.Create(user);
            return _mapper.Map<EmployeeDTO>(user);
        }

        public void Update(EmployeeDTO employee)
        {
            var updateproject = _mapper.Map<Employee>(employee);
            employeeRepository.Update(updateproject);

        }

        public void Remove(Guid id)
        {
            employeeRepository.Remove(id);
        }
    }
}
