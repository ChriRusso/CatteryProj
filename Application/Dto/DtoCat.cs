using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
namespace Application.Dto
{
    public record class DtoCat
    (
        string Name,
        string Race,
        Sex Sex,
        string Description,
        DateOnly? birth,
        DateOnly arrived,
        DateOnly? left,
        string? catImage,
        string cui
    );
}
