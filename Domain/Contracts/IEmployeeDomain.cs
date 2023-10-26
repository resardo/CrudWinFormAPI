using DTO.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IEmployeeDomain
    {
        IList<EmployeeDTO> GetAllUsers();
        EmployeeDTO GetUserById(Guid id);
        EmployeeDTO Create(EmployeeDTO employee);
        void Update(EmployeeDTO employee);

        void Remove(Guid id);
    }
}
