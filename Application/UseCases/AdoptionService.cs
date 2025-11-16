using Application.Interfaces;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.UseCases
{
    public class AdoptionService
    {
        IModelRepository<Cat> _catRepo;
        IModelRepository<Adoption> _adoptionRepo;
        IModelRepository<Adopter> _adopterRepo;
        public AdoptionService(IModelRepository<Cat> catRepo, IModelRepository<Adoption> adoptionRepo)
        {
            _catRepo = catRepo;
            _adoptionRepo = adoptionRepo;
        }
        public void AdoptCat(Cat cat, Adopter adopter, DateOnly adoptionDate)
        {
            cat.LeftCattery = adoptionDate;
            Adoption adoption = new Adoption(cat, adopter, adoptionDate);
            List<Adoption> adoptions = new List<Adoption>(_adoptionRepo.GetAll());
            adoptions.Add(adoption);
            RemoveCat(cat);
        }
        private void RemoveCat(Cat cat)
        {
            _catRepo.RemoveFromRepo(cat);
        }
        public void RefundCat(Cat cat, DateOnly refundDate)
        {
          
            Adoption adoption = SearchAdoptionByCat(cat);
            adoption.AdoptionCat.Description += $"Adoption Failed: Started on: {adoption.AdoptionDate} and ended on: {refundDate}";
            adoption.AdoptionCat.LeftCattery = null;
            _adoptionRepo.RemoveFromRepo(adoption);
            _catRepo.AddToRepo(cat);
        }
        private Adoption SearchAdoptionByCat(Cat cat)
        {
            List<Adoption> AllAdoptions = new List<Adoption>(_adoptionRepo.GetAll());
            for (int catPos = 0; catPos < AllAdoptions.Count(); catPos++)
            {
                if (cat == AllAdoptions[catPos].AdoptionCat)
                {
                    return AllAdoptions[catPos];
                }
            }
            throw new ArgumentException("Cat not found on the cattery list");
        }
        public void AddAdopter(Adopter adopter)
        {
            _adopterRepo.AddToRepo(adopter);
        }
    }
}
