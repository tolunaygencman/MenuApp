using AutoMapper;
using MenuApp.Business.DTOs.Categories;
using MenuApp.Business.DTOs.Foods;
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

            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, MenuUpdateDto>().ReverseMap();
            CreateMap<Menu, MenuUpdateWithoutImgDto>().ReverseMap();

            //Create Category

            CreateMap<Category, CategoryDto>().ReverseMap();

            //Create Food
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodUpdateDto>().ReverseMap();
            CreateMap<Food, FoodUpdateWithoutImgDto>().ReverseMap();
        }
    }
}
