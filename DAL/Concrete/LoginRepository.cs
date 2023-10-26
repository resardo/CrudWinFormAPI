using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class LoginRepository : BaseRepository<Employee, Guid>, ILoginRepository
    {


        public LoginRepository(PersonContext dbContext) : base(dbContext)
        {
        }

        public Employee Generate(Employee employee)
        {
            var login = context.Include(x => x.EmployeeRoles).ThenInclude(x => x.Role).Where(a => a.Username == employee.Username && a.Password == employee.Password).FirstOrDefault();
            return login ?? null;
        }
    }
}
