using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;
using Application.Dto;
namespace DomainTest
{
    public class Class1
    {
        [TestMethod]
        public void AdoptionMapper_ToEntity_ThrowsOnNull()
        {
            DtoAdoption? nullDto = null;
            Assert.ThrowsException<ArgumentNullException>(() => nullDto!.ToEntity());
        }

        [TestMethod]
        public void AdoptionMapper_ToDto_ThrowsOnNull()
        {
            Adoption? nullEntity = null;
            Assert.ThrowsException<ArgumentNullException>(() => nullEntity!.ToDto());
        }
    }

}
