using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObject;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToEntity(this DtoCat dto)
        {
            return new Cat(
                dto.Name,
                dto.Race,
                dto.Sex,
                dto.Description,
                dto.birth,
                dto.arrived,
                dto.left,
                dto.catImage
                );
        }
        public static DtoCat ToDto(this Cat cat)
        {
            return new DtoCat(
                cat.Name,
                cat.Race,
                cat.CatSex,
                cat.Description,
                cat.Birth,
                cat.ArrivedToCattery,
                cat.LeftCattery,
                cat.CatImage,
                cat.Cui
                );
        }
    }
}
