﻿using AutoMapper;
using Core.Entities.Models;
using Core.Shared.DataTransferObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<AttributeValue, ProductDto>();
        }
    }
}
