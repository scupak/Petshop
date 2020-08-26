using Petshop.core.DomainServices;
using Petshop.Core.Entity;
using System;
using System.Collections.Generic;

namespace Petshop.infraStructure.Data
{
    public class PetRepository : IPetRepository
    {
        public int Id;
        public List<Pet> Pets;


        public PetRepository()
        {
            Id = 0;
            Pets = new List<Pet>();


        }

        public void InitData()
        {
            AddPet(new Pet("hulk", DateTime.Now, "green", "marek", 40, PetType.Goat, DateTime.Now));
            AddPet(new Pet("hulk", DateTime.Now, "green", "marek", 20, PetType.Goat, DateTime.Now));
            AddPet(new Pet("hulk", DateTime.Now, "green", "marek", 50, PetType.Goat, DateTime.Now));
            AddPet(new Pet("hulk", DateTime.Now, "green", "marek", 30, PetType.Goat, DateTime.Now));
            AddPet(new Pet("hulk", DateTime.Now, "green", "marek", 40, PetType.Goat, DateTime.Now));

            //Pets = Pets.OrderBy(o=>o.Price).ToList();

        }

        public Pet AddPet(Pet pet)
        {

            Id++;
            pet.Id = Id;
            Pets.Add(pet);
            return pet;




        }

        public Pet EditPet(Pet pet, int index)
        {

            Pets[index] = pet;
            return Pets[index];

        }

        public List<Pet> GetPets()
        {
            return Pets;
        }
    }
}
