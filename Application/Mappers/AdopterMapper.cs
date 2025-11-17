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
    public static class AdopterMapper
    {
        public static Adopter ToEntity(this DtoAdopter dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            return new Adopter(
                dto.Name,
                dto.Surname,
                new Address(dto.Address.Street, dto.Address.City, dto.Address.PostalCode, dto.Address.Country),
                new PhoneNumber(dto.PhoneNumber),
                new FiscalCode(dto.FiscalCode)
                );


        }
    }
}
