using System;
using Application.Dto;
using Domain.Model.Entities;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToEntity(this DtoAdoption dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

           

            return new Adoption(dto.Cat.ToEntity(), dto.Adopter, dto.date);
        }

        public static DtoAdoption ToDto(this Adoption adoption)
        {
            if (adoption == null) throw new ArgumentNullException(nameof(adoption));

           

            return new DtoAdoption(adoption.AdoptionCat.ToDto(), adoption.AdoptionAdopter, adoption.AdoptionDate);
        }
    }
}