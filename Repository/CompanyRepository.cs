using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Context;

namespace Repository
{
    public class CompanyRepository:RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext RepositoryContext):base(RepositoryContext)
        {
        }

        public void CreateCompany(Company company)
        {
            if(company!=null)
            Create(company);
        }

        public void DeleteCompany(Company company)
        {
            if(company !=null)
            Delete(company);
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
        //return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        return FindAll(trackChanges).ToList();
        }

        public Company GetCompany(Guid CompanyId, bool trackchnages)
        {
            return FindByCondition(c => c.Id.Equals(CompanyId),trackchnages).SingleOrDefault();
        }

        public void UpdateCompany(Company company)
        {
            if(company!=null)
             Update(company);
        }
    }
}
