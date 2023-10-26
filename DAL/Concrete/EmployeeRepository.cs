using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;


namespace DAL.Concrete
{
    internal class EmployeeRepository : BaseRepository<Employee, Guid>, IEmployeeRepository
    {

        public EmployeeRepository(PersonContext dbContext) : base(dbContext)
        {
        }
  
        public void Create(Employee employee)
        {
            context.Add(employee);
            db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            if (db.Entry(employee).State == EntityState.Detached)
                context.Attach(employee);
            
            //context.Update(project);
            SetModified(employee);
            PersistChangesToTrackedEntities();
        }


        public Employee GetById(Guid id)
        {
            var user = context.Where(a => a.EmployeeId == id).FirstOrDefault();
            return user;
        }


        public void Remove(Guid id)
        {
            Employee emp = context.Find(id);
            if (emp != null)
                Remove(emp);
            
            PersistChangesToTrackedEntities();
        }

    }

}
