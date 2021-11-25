using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Context;

namespace Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private RepositoryContext _RepositoryContext;
        private ICompanyRepository _CompanyRepository;
        private IEmployeeRepository _EmployeeRepository;
        private ILoggerManager _logger;

        public RepositoryManager(RepositoryContext RepositoryContext,ILoggerManager logger)
        {
            _RepositoryContext = RepositoryContext;
            _logger = logger;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_CompanyRepository == null)
                    _CompanyRepository = new CompanyRepository(_RepositoryContext);
                return _CompanyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_EmployeeRepository == null)
                    _EmployeeRepository = new EmployeeRepository(_RepositoryContext);
                return _EmployeeRepository;
            }
        }

        public void Save()
        {
                _RepositoryContext.SaveChanges();

        }
    }
}
