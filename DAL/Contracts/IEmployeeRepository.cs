using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee, Guid>
    {
        Employee GetById(Guid id);
        void Create(Employee employee);
        void Update(Employee employee);

        void Remove(Guid id);

    }

}
