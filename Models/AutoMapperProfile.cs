using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Account;
using Models.Accounts;

namespace Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountDto, Account>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.FName))
                .ReverseMap();

            CreateMap<AccountAddressDto, AccountAddress>()       .ReverseMap();


        }


    }
}
