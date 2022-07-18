using System;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main()
        {
            var citizens = new List<Citizen>();
            
            while (true)
            {
                var line = Console.ReadLine();
                var tokens = line.Split();
                if(line == "End")
                {
                    break;
                }
                Citizen citizen;
                citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                citizens.Add(citizen);                

            }
            foreach (var item in citizens)
            {
                Console.WriteLine(item.GetName());
            }
           
        }
    }
}
