using Petshop.core.ApplicationServices;
using Petshop.core.DomainServices;
using Petshop.infraStructure.Data;

namespace Petshop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();
            petRepository.InitData();
            IPetService petService = new PetService(petRepository);
            Printer print = new Printer(petService);
            print.PrintMenu();
        }

    }
}
