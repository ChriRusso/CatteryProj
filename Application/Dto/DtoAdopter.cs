using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.ValueObject;
namespace Application.Dto
{
    public record class DtoAdopter
    {
        string Name;
        string Username;
        Address Address;
        PhoneNumber PhoneNumber;
        FiscalCode FiscalCode;

    }
}
