
using Entities.Model;


namespace DAL.Contracts
{
    public interface ILoginRepository : IRepository<Employee, Guid>
    {
       Employee Generate(Employee emp);
    }
}
