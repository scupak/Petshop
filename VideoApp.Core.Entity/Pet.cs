using System;

namespace Petshop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
        public PetType PetType { get; set; }

        public Pet(string name, DateTime birthdate, string color, string previousOwner, double price, PetType petType, DateTime soldDate)
        {
            Name = name;
            Birthdate = birthdate;
            Color = color;
            PreviousOwner = previousOwner;
            Price = price;
            PetType = petType;
            SoldDate = soldDate;

        }

        public override string ToString()
        {
            return ($"{Id}:{Name}:{Birthdate}:{SoldDate}:{Color}:{PreviousOwner}:{PetType}:{Price}");
        }
    }
}
