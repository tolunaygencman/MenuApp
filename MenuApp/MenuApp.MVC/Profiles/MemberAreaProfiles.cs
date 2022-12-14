using AutoMapper;
using MenuApp.Business.DTOs.Members;
using MenuApp.Business.DTOs.Menus;
using MenuApp.Entity.Concretes;
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
            CreateMap<MenuListVM, MenuListDTO>().ReverseMap();
            CreateMap<MenuCreateDTO, Menu>();
            CreateMap<Menu, MenuListDTO>();
            CreateMap<MenuCreateVM,MenuCreateDTO>().ForMember(dest => dest.BackgroundImage, src => src.MapFrom(x => Convert.ToBase64String(x.BackgroundImage.GetBytesAsync().GetAwaiter().GetResult())));
        }
    }
}
