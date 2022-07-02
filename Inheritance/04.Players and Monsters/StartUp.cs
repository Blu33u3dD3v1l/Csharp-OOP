using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main()
        {
            Elf elf = new Elf("Ivan", 100);
            Console.WriteLine(elf.ToString());
            Knight knight = new Knight("Viktor", 10000);
            Console.WriteLine(knight);
        }
    }
}
