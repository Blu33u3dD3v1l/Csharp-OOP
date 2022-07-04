using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<Person> persones = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split();
                var person = new Person(cmd[0], cmd[1], int.Parse(cmd[2]));
                persones.Add(person);
            }
            foreach (var item in persones)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
