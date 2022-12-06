using AutoMapper;
using MenuApp.Business.DTOs.Members;
using MenuApp.Entity.Concretes;
using MenuApp.MVC.Extensions;
using MenuApp.MVC.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Profiles
{
    public class MemberAreaProfiles : Profile
    {
        public MemberAreaProfiles()
        {
            //Create Member
            CreateMap<RegisterVM, MemberCreateDto>().ForMember(dest => dest.Image, src => src.MapFrom(x => Convert.ToBase64String(x.Image.GetBytesAsync().GetAwaiter().GetResult())));
        }
    }
}
