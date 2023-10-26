using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.FormDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;


namespace Domain.Concrete
{
    internal class FormDomain : DomainBase, IFormDomain
    {

        public FormDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IFormRepository formRepository => _unitOfWork.GetRepository<IFormRepository>();

        public IList<FormDTO> GetAllForms()
        {
            IEnumerable<Form> forms = formRepository.GetAllForms();
            var formsList = _mapper.Map<IList<FormDTO>>(forms);
            return formsList;
        }
        public FormDTO Add(FormDTO form)
        {
            var data = _mapper.Map<FormDTO, Form>(form);
            data.FormId = Guid.NewGuid();
            var FormData = formRepository.Add(data);

            var FormDTOdata = _mapper.Map<Form, FormDTO>(FormData);
            return FormDTOdata;
        }

        public IList<FormDTO> GetFormByName(string name)
        {

            IEnumerable<Form> form = formRepository.GetByName(name);
            return _mapper.Map<IList<FormDTO>>(form);
        }

        public FormDTO GetFormById(Guid id)
        {

            Form form = formRepository.GetById(id);
            return _mapper.Map<FormDTO>(form);
        }

        public void Remove(Guid id)
        {
            formRepository.Remove(id);
        }

        public void Update(FormDTO form)
        {
            var formToUpdate = _mapper.Map<Form>(form);
           
            formRepository.Update(formToUpdate);
        }
    }
}
