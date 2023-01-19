using AutoMapper;
using MenuApp.Business.DTOs.Display;
using MenuApp.MVC.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Profiles
{
    public class DisplayProfiles : Profile
    {
        public DisplayProfiles()
        {
            CreateMap<DisplayCategoriesDto, DisplayCategoriesVM>();
            CreateMap<DisplayFoodsDto, DisplayFoodsVM>();

        }
    }
}
