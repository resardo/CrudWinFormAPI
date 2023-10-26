using Entities.Model;


namespace DAL.Contracts
{
    public interface IFormRepository: IRepository<Form, Guid>
    {
        IEnumerable<Form> GetAllForms();
        IEnumerable<Form> GetByName(string name);
        Form Add(Form form);
        void Update(Form form);
        void Remove(Guid id);
    }
}
