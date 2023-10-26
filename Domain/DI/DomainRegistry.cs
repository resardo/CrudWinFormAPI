using DAL.DI;
using Domain.Concrete;
using Domain.Contracts;
using Lamar;
using Microsoft.AspNetCore.Http;


namespace Domain.DI
{
    public class DomainRegistry : ServiceRegistry
    {
        public DomainRegistry()
        {
            IncludeRegistry<DomainUnitOfWorkRegistry>();
            For<ILoginDomain>().Use<LoginDomain>();
            For<IFormDomain>().Use<FormDomain>();
            For<IEmployeeDomain>().Use<EmployeeDomain>();
            For<IRoleDomain>().Use<RoleDomain>();

            AddRepositoryRegistries();
            AddHttpContextRegistries();
        }

        private void AddRepositoryRegistries()
        {
            IncludeRegistry<RepositoryRegistry>();
        }

        private void AddHttpContextRegistries()
        {
            For<IHttpContextAccessor>().Use<HttpContextAccessor>();
        }
    }
}
