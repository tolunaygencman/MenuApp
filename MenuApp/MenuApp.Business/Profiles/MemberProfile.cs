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

            //Menu

            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, MenuUpdateDto>().ReverseMap();
            CreateMap<Menu, MenuUpdateWithoutImgDto>().ReverseMap();

            //Category

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateWithoutImgDto>().ReverseMap();

            // Food
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodUpdateDto>().ReverseMap();
            CreateMap<Food, FoodUpdateWithoutImgDto>().ReverseMap();
        }
    }
}
