using AutoMapper;
using MenuApp.Business.DTOs.Admins;
using MenuApp.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDto>();
        }
    }
}
