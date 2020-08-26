using Petshop.Core.Entity;
using System.Collections.Generic;

namespace Petshop.core.DomainServices
{
    public interface IPetRepository
    {
        public Pet AddPet(Pet video);

        public Pet EditPet(Pet video, int index);

        public List<Pet> GetPets();

        public void InitData();

    }
}
