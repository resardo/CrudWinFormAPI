using DTO.FormDTO;


namespace Domain.Contracts
{
    public interface IFormDomain
    {
        IList <FormDTO> GetAllForms();
        IList <FormDTO> GetFormByName(string name);
        FormDTO GetFormById(Guid id);
        FormDTO Add(FormDTO job);
        void Update(FormDTO job);
        void Remove(Guid id);
    }
}
