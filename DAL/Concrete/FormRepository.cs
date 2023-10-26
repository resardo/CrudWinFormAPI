using DAL.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Concrete
{
    internal class FormRepository : BaseRepository<Form, Guid>, IFormRepository
    {

        public FormRepository(PersonContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Form> GetByName(string name)
        {
            var form = context.Where(a => a.Emri == name).ToList();
            return form;

        }

        public Form Add(Form form)
        {
            context.Add(form);
            PersistChangesToTrackedEntities();
            return context.Add(form).Entity;
        }

        public void Update(Form form)
        {
            if (db.Entry(form).State == EntityState.Detached)
                context.Attach(form);
            
            //context.Update(project);
            SetModified(form);
            PersistChangesToTrackedEntities();
        }

        public void Remove(Guid id)
        {
            Form jobToRemove = context.Find(id);
            if (jobToRemove != null)
            {
                Remove(jobToRemove);
            }
            PersistChangesToTrackedEntities();
        }

        public IEnumerable<Form> GetAllForms()
        {
             return context.ToList();
        }
    }
}
