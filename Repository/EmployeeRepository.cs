using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Paging;

namespace Repository
{
    public class EmployeeRepository:RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext RepositoryContext) : base(RepositoryContext)
        {
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            return FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                    .OrderBy(e => e.Name)
                    .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                    .Take(employeeParameters.PageSize)
                    .ToList();
        }
        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {

          return FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id),trackChanges).SingleOrDefault();
        }

    }
}
