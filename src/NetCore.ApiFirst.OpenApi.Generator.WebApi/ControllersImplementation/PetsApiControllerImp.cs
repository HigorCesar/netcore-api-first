using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCore.ApiFirst.OpenApi.Generator.WebApi.ControllersInterface;
using NetCore.ApiFirst.OpenApi.Generator.WebApi.Models;

namespace NetCore.ApiFirst.OpenApi.Generator.WebApi.ControllersImplementation
{
    public class PetsApiControllerImp : PetsApiController
    {
        private List<Pet> fakePets = new List<Pet>
        {
            new Pet
            {
                Id = 1,
                Name = "Miles",
                Tag = "Miles"
            },
            new Pet
            {
                Id = 2,
                Name = "Pedrinho",
                Tag = "Pedrinho"
            },
            new Pet
            {
                Id = 3,
                Name = "Ruy",
                Tag = "Ruy"
            },
            new Pet
            {
                Id = 4,
                Name = "Neto",
                Tag = "Neto"
            }
        };
        public override IActionResult AddPet(NewPet newPet)
        {
            var pet = new Pet{ Name = newPet.Name, Tag = newPet.Tag, Id = fakePets.Count +1};
            fakePets.Add(pet);
            //TODO: Change the data returned
            return new ObjectResult(pet);
        }

        public override IActionResult DeletePet(long id)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult FindPetById(long id)
        {
            return new ObjectResult(fakePets.FirstOrDefault(x=>x.Id ==id));
        }

        public override IActionResult FindPets(List<string> tags, int limit)
        {
            return new ObjectResult(fakePets);
        }
    }
}