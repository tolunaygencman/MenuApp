using AutoMapper;
using MenuApp.Business.DTOs.Categories;
using MenuApp.Business.DTOs.Foods;
using MenuApp.Business.DTOs.Members;
using MenuApp.Business.DTOs.Menus;
using MenuApp.Entity.Concretes;
using MenuApp.MVC.Areas.Member.Models.CategoryVMs;
using MenuApp.MVC.Areas.Member.Models.FoodVMs;
using MenuApp.MVC.Areas.Member.Models.MenuVMs;
using MenuApp.MVC.Extensions;
using MenuApp.MVC.Models.VMs;
using System;

namespace MenuApp.MVC.Profiles
{
    public class MemberAreaProfiles : Profile
    {
        public MemberAreaProfiles()
        {
            //Member
            CreateMap<MemberCreateDto, Member>();
            CreateMap<RegisterVM, MemberCreateDto>().ForMember(dest => dest.Image, src => src.MapFrom(x => Convert.ToBase64String(x.Image.GetBytesAsync().GetAwaiter().GetResult())));

            // Menu
            CreateMap<MenuListVM, MenuListDto>().ReverseMap();
            CreateMap<Menu, MenuListDto>();

            CreateMap<MenuCreateDto, Menu>();
            CreateMap<MenuCreateVM, MenuCreateDto>().ForMember(dest => dest.BackgroundImage, src => src.MapFrom(x => Convert.ToBase64String(x.BackgroundImage.GetBytesAsync().GetAwaiter().GetResult())));

            CreateMap<MenuUpdateDto, Menu>();
            CreateMap<MenuDto, MenuUpdateVM>().ForMember(dest => dest.BackgroundImage, src => src.MapFrom(x => x.BackgroundImage.GetFormFileAsync("BackgroundImage").GetAwaiter().GetResult()));
            CreateMap<MenuUpdateVM, MenuUpdateDto>().ForMember(dest => dest.BackgroundImage, src => src.MapFrom(x => Convert.ToBase64String(x.BackgroundImage.GetBytesAsync().GetAwaiter().GetResult())));

            //Category
            CreateMap<CategoryListVM, CategoryListDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryCreateVM, CategoryCreateDto>().ForMember(dest => dest.Image, src => src.MapFrom(x => Convert.ToBase64String(x.Image.GetBytesAsync().GetAwaiter().GetResult())));

            //Food
            CreateMap<FoodListVM, FoodListDto>().ReverseMap();
        }

    }
}
