using AutoMapper;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Maps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserToRegisterDTO, ApplicationUser>();
            CreateMap<TransactionMethodToAddDTO, TransactionMethod>();
            CreateMap<TransactionToAddDTO, Transaction>();
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<UserDTO, ApplicationUser>();
            CreateMap<TransactionMethodToUpdate, TransactionMethod>();
        }
    }
}
