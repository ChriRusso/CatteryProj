using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record class DtoAdoption(
        DtoCat Cat,
        Adopter Adopter,
        DateOnly date
        );
    
        
    
}
