using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());                      
            var heroes = new List<BaseHero>();
           

            for (int i = 0; i < n; i++)
            {
                var playersName = Console.ReadLine();
                var className = Console.ReadLine();
                BaseHero hero = null;


                if (className == "Paladin")
                {
                    hero = new Paladin(playersName);

                }
                else if (className == "Druid")
                {
                    hero = new Druid(playersName);                           
                  

                }
                else if (className == "Rogue")
                {
                    hero = new Rogue(playersName);                   
                   

                }
                else if (className == "Warrior")
                {
                    hero = new Warrior(playersName);                               
                   

                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                   
                }
                heroes.Add(hero);
            

            }



            var num = int.Parse(Console.ReadLine());
            var a = heroes.Sum(x => x.Power);
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
            }
            if(a >= num)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
