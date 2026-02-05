using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayerApp.Core.DTOs.CategoryDTOs;
using NLayerApp.Core.Entities;

namespace NLayerApp.Business.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
