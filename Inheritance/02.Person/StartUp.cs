using System;

namespace Person
{
    public class StartUp
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Person person = new Person(name, age);
            if (person.Age >= 0 && child.Age > 0 &&  child.Age <= 15)
            {
                Console.WriteLine(child);
            }
          
        }
    }
}
