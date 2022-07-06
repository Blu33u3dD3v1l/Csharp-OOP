using System;
using System.Linq;
using System.Collections.Generic;

namespace Tst
{
    internal class StartUp
    {
        static void Main()
        {
            
            var namesAndMoney = new Dictionary<string, Person>();
            var productsAndCosts = new Dictionary<string, Product>();
            var line = Console.ReadLine().Split(';',
                StringSplitOptions.RemoveEmptyEntries);
            var line1 = Console.ReadLine().Split(';' , StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < line.Length; i++)
            {
                var tokens = line[i].Split('=');
                var name = tokens[0];
                var money = double.Parse(tokens[1]);
                Person person = new Person(name, money);
                namesAndMoney[name] = person;

            }
            for (int i = 0; i < line1.Length; i++)
            {
                var tokens = line1[i].Split('=');
                var product = tokens[0];
                var cost = int.Parse(tokens[1]);
                Product products = new Product(product , cost);
                productsAndCosts[product] = products;
            }
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }
                var tokens = cmd.Split();
                var name = tokens[0];
                var product = tokens[1];
                bool a = namesAndMoney.ContainsKey(name);
                bool b = productsAndCosts.ContainsKey(product);
                if (a = true && b == true)
                {
                    if (namesAndMoney[name].Money >= productsAndCosts[product].Cost)
                    {
                        Console.WriteLine($"{name} bought {product}");
                        namesAndMoney[name].Money -= productsAndCosts[product].Cost;
                        namesAndMoney[name].BagOfProducts.Add(product);
                    }
                    else
                    {                      
                        Console.WriteLine($"{name} can't afford {product}");  
                    }
                }
            }
            foreach (var item in namesAndMoney)
            {
                Console.Write($"{item.Key} - ");
                if(item.Value.BagOfProducts.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{string.Join(", ",item.Value.BagOfProducts)}");
                }
            }

        }
    }
}