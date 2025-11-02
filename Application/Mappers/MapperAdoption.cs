using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 
namespace Application.Mappers
{
    public static class MapperAdoption
    {
        public static Adopter ToEntity(DtoAdoption dto) {
            return new DtoAdoption
            {
                Cat = DtoAdoption.Cat
            }
                

        }
    }
}
