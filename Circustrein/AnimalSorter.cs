﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    class AnimalSorter
    {
        private List<Animal> carnivoreAnimals = new List<Animal>();
        private List<Animal> herbivoreAnimals = new List<Animal>();

        public List<Animal> CarnivoreAnimals { get => carnivoreAnimals; set => carnivoreAnimals = value; }
        public List<Animal> HerbivoreAnimals { get => herbivoreAnimals; set => herbivoreAnimals = value; }




        /// <summary>
        /// Sorts the Animals into Herbivores and Carnivores
        /// </summary>
        public void SetAnimals(List<Animal> animals, List<Wagon> wagons)
        {
            foreach (Wagon wagon in wagons)
            {
                foreach (Animal animal in wagon.Animals)
                {
                    if (animal.FoodType == "Herbivore")
                    {
                        herbivoreAnimals.Add(animal);
                    }
                    else //FoodType == Carnivores
                    {
                        carnivoreAnimals.Add(animal);
                    }
                }
            }

            foreach (Animal animal in animals)
            {
                if (animal.FoodType == "Herbivore")
                {
                    herbivoreAnimals.Add(animal);
                }
                else //FoodType == Carnivores
                {
                    carnivoreAnimals.Add(animal);
                }
            }

            
        }



        /// <summary>
        /// Checks if the to be added Animal is the smallest in the wagon
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="wagon"></param>
        /// <returns></returns>
        public bool IsThisTheSmallestAnimal(Animal animal, Wagon wagon)
        {
            if (wagon.SmallestAnimal >= animal.PointWorth)
            {
                return false;
            }
            else if (wagon.SmallestAnimal < animal.PointWorth && wagon.SmallestAnimalIsCarnivore == true)
            {
                return true;
            }
            else
            {
                wagon.SmallestAnimal = animal.PointWorth;
                if (animal.FoodType == "Carnivore")
                {
                    wagon.SmallestAnimalIsCarnivore = true;
                }
                return true;
            }
        }


    }
}
