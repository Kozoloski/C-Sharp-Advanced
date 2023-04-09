using Domain.Models;
using System.ComponentModel;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;

PetStore<Dog> dogStore = new PetStore<Dog>();
PetStore<Cat> catStore = new PetStore<Cat>();
PetStore<Fish> fishStore = new PetStore<Fish>();

dogStore.Insert(new Dog() { Name = "Jack", Type = "Dog", Age =6 });
dogStore.Insert(new Dog() { Name = "Back", Type = "Dog", Age = 2 });

dogStore.BuyPet("Jack");
dogStore.printPets();

catStore.Insert(new Cat() { Name = "Tom", Type = "Cat", Age = 3 });
catStore.Insert(new Cat() { Name = "Leo", Type = "Cat", Age = 5 });

catStore.BuyPet("Tom");
catStore.printPets();

fishStore.Insert(new Fish() { Name = "Nemo", Type = "Fish", Age = 1 });
fishStore.Insert(new Fish() { Name = "Gill", Type = "Fish", Age = 5 });

fishStore.printPets();

Console.ReadLine();