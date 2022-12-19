using AutoMapper;
using MenuApp.Business.DTOs.Categories;
using MenuApp.Business.DTOs.Members;
using MenuApp.Business.DTOs.Menus;
using MenuApp.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuApp.Business.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>();

            //Create Menu

            CreateMap<Menu, MenuDTO>().ReverseMap();

            //Create Category

            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
