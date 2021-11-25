using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompaniesController(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }
        //[HttpGet,Authorize(Roles ="Manager")]

        public IActionResult GetCompanies()
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackchanges: false);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            //throw new Exception("Exception");
            #region Old
            //var companiesDto = companies.Select(c => new CompanyDto()
            //{
            //    Id = c.Id,
            //    Name=c.Name,
            //    FullAddress=$"{c.Address} - {c.Country}"
            //});
            #endregion
            return Ok(companiesDto);
        }
        //public IActionResult hello()
        //{
        //    return NotFound();
        //}
        [HttpGet("{id}", Name = "CompanyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _repositoryManager.Company.GetCompany(id, trackchanges: false);
            if (company == null)
            {
                _logger.LogError($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                //var companydto = _mapper.Map<CompanyDto>(company);
                return Ok(company);
            }
        }
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");

                return BadRequest("CompanyForCreationDto object is null");
            }
            var companyEntity = _mapper.Map<Company>(company);
            _repositoryManager.Company.CreateCompany(companyEntity);
            _repositoryManager.Save();
            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return CreatedAtRoute("CompanyById", new { id = companyToReturn.Id },
           companyToReturn);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var company = _repositoryManager.Company.GetCompany(id, trackchanges: false);
            if (company == null)
            {
                _logger.LogError($"Company with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repositoryManager.Company.DeleteCompany(company);
            _repositoryManager.Save();
            return NoContent();

        }
    }
}
