using System;
using WildFarm.Classes;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main()
        {

            var animals = new List<Animal>();
            Animal animal;

            while (true)
            {
               
                var line = Console.ReadLine();
                if(line == "End")
                {
                    break;
                }
                var line1 = Console.ReadLine();

                var lineTokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var line1Tokens = line1.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineTokens[0] == "Hen")
                {
                    
                    animal = new Hen(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), double.Parse(lineTokens[3]));
                    animal.Weight += animal.FoodEaten * 0.35;
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);
                   
                }
                else if (lineTokens[0] == "Owl")
                {
                    animal = new Owl(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), double.Parse(lineTokens[3]));
                    if (line1Tokens[0] == "Meat")
                    {
                        
                        animal.Weight += animal.FoodEaten * 0.25;
                        Console.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                    }
                    else
                    {
                        animal.FoodEaten = 0;
                        animals.Add(animal); animal = new Owl(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), double.Parse(lineTokens[3]));

                        Console.WriteLine($"{lineTokens[0]} does not eat {line1Tokens[0]}!");
                   
                    }

                }
                else if (lineTokens[0] == "Cat")
                {
                    animal = new Cat(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), lineTokens[3], lineTokens[4]);
                    Console.WriteLine(animal.ProduceSound());
                    if (line1Tokens[0] == "Meat" || line1Tokens[0] == "Vegetable")
                    {
                        animal.Weight += animal.FoodEaten * 0.30;
                        animals.Add(animal);
                    }
                    else
                    {
                        animal.FoodEaten = 0;
                        Console.WriteLine($"{lineTokens[0]} does not eat {line1Tokens[0]}!");
                    }
                    
                   
                }
                else if (lineTokens[0] == "Tiger")
                {
                    animal = new Tiger(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), lineTokens[3], lineTokens[4]);
                    Console.WriteLine(animal.ProduceSound());
                    if (line1Tokens[0] == "Meat")
                    {
                        animal.Weight += animal.FoodEaten * 1.0;
                        animals.Add(animal);
                    }
                    else
                    {
                        animal.FoodEaten = 0;
                        animals.Add(animal);
                        Console.WriteLine($"{lineTokens[0]} does not eat {line1Tokens[0]}!");
                    }
                }
                else if (lineTokens[0] == "Dog")
                {
                    animal = new Dog(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), lineTokens[3]);
                    Console.WriteLine(animal.ProduceSound());
                    if (line1Tokens[0] == "Meat")
                    {
                        animal.Weight += animal.FoodEaten * 0.40;
                        animals.Add(animal);
                    }
                    else
                    {
                        animal.FoodEaten = 0;
                        animals.Add(animal);
                        Console.WriteLine($"{lineTokens[0]} does not eat {line1Tokens[0]}!");
                    }
                }
                else if (lineTokens[0] == "Mouse")
                {
                    animal = new Mouse(lineTokens[1], double.Parse(lineTokens[2]), int.Parse(line1Tokens[1]), lineTokens[3]);
                    Console.WriteLine(animal.ProduceSound());
                    if (line1Tokens[0] == "Vegetable" || line1Tokens[0] == "Fruit")
                    {
                        animal.Weight += animal.FoodEaten * 0.10;
                        animals.Add(animal);
                    }
                    else
                    {
                        animal.FoodEaten = 0;
                        animals.Add(animal);
                        Console.WriteLine($"{lineTokens[0]} does not eat {line1Tokens[0]}!");
                    }
                }
              
            }
            foreach (var item in animals)
            {
                
                Console.WriteLine(item);
            }
        }
    }
}
