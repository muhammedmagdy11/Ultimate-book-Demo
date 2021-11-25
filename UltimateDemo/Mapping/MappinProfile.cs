using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UltimateDemo.Mapping
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(c=>c.FullAddress,opt=>opt.MapFrom(x=>$"{x.Address} - {x.Country}"));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<CompanyForCreationDto, Company>();

        }
    }
}
