﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    class CheckWagon
    {

        private List<Animal> animalsInWagon = new List<Animal>();
        private AnimalSorter animalSorter;


        public CheckWagon(AnimalSorter animalSorter)
        {
            this.animalSorter = animalSorter;
        }


        /*
         * public bool WhatIsTheWagonWeight(Animal animal, Wagon wagon)
        {
            if (wagon.Full != true)
            {
                if (wagon.Weight == 0)
                {
                    wagon.AddAnimal(animal);

                    IsThisTheSmallestAnimal(animal, wagon);

                    return true;
                    //you can add anything
                }
                else
                {
                    return CanThisAnimalGoInTheWagon(wagon, animal);
                }
            }
            return false;
        }*/


        public bool IsTheWagonEmpty(Wagon wagon)
        {
            if (wagon.Full == false && wagon.Weight == 0)
            {
                 return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the animal can be added to the wagon
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CanThisAnimalGoInTheWagon(Wagon wagon, Animal animal)
        {


            animalsInWagon = wagon.Animals;
            if (wagon.ContainsCarnivore == true)
            {
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else //(animal.FoodType == "Herbivore")
                {
                    //added this first
                    return CarnInWagon(wagon, animal);
                }
            }
            else //doesn't have a carnivore 
            {
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    return CarnNotInWagon(wagon, animal);
                }
                else // add herb
                {
                    return CarnNotInWagon(wagon, animal);
                }
            }
        }

        /// <summary>
        /// Continue checken when there is no carn in the wagon yet
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CarnNotInWagon(Wagon wagon, Animal animal)
        {
            if (animal.FoodType == AnimalType.Carnivore)
            {
                if (animal.AnimalSize < wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    wagon.AddAnimal(animal);
                    IsThisTheSmallestAnimal(animal, wagon);
                    return true;
                }
            }
            else if (animal.FoodType != AnimalType.Carnivore)
            {
                if (wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    wagon.AddAnimal(animal);
                    IsThisTheSmallestAnimal(animal, wagon);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continue checken when there is no carn in the wagon yet
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CarnInWagon(Wagon wagon, Animal animal)
        {
            //this was for the herb when haveing a carn in the wagon
            if (animal.AnimalSize > wagon.SmallestAnimal && wagon.SmallestAnimalIsCarnivore == true && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                IsThisTheSmallestAnimal(animal, wagon);
                return true;
            }
            else if (wagon.SmallestAnimalIsCarnivore == false && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                IsThisTheSmallestAnimal(animal, wagon);
                return true;
            }
            else if (animal.AnimalSize > wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                return true;
            }
            return false;
        }

        public bool IsThisTheSmallestAnimal(Animal animal, Wagon wagon)
        {
            //when the animal in the wagon is bigger than the to be added animal
            if (wagon.SmallestAnimal >= animal.AnimalSize)
            {
                return false;
            }
            //when the animal in the wagon is smaller than the to be added animal and the to wagon has a Carn
            else if (wagon.SmallestAnimal < animal.AnimalSize && wagon.SmallestAnimalIsCarnivore == true)
            {
                return true;
            }
            else
            {
                wagon.SmallestAnimal = animal.AnimalSize;
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    wagon.SmallestAnimalIsCarnivore = true;
                }
                return true;
            }
        }
    }
}