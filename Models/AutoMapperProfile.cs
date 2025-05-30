﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Account;
using Entities.Games;
using Models.Accounts;

namespace Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountDto, Account>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.FName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.LName))
                .ReverseMap();

            CreateMap<AccountAddressDto, AccountAddress>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<GameDto, Game>()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ReverseMap();












        }


    }
}
