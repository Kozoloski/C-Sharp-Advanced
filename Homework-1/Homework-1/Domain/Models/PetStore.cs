using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PetStore <T> where T : Pet
    {
        public List<T> ListOfPets { get; set; } = new List<T>();

     
        public void printPets()
        {
            Console.WriteLine("\nPets left in the store:");
            foreach (T pet in ListOfPets)
            {

                Console.WriteLine(pet.PrintInfo());
            }
        }


        public void Insert(T pet)
        {
            ListOfPets.Add(pet);
            
            Console.WriteLine($"{pet.Name} was added in the {pet.GetType().Name} PetStore");
        }

        public void BuyPet(string name)
        {
            T pet = ListOfPets.FirstOrDefault(x => x.Name == name);
            if (pet == null)
            {
                Console.WriteLine("There is no such pet");

            }
            ListOfPets.Remove(pet);
            Console.WriteLine($"Congratulation!!! You successfully bought {pet.Name} from {pet.GetType().Name} PetStore");
        }
    }

  
}
