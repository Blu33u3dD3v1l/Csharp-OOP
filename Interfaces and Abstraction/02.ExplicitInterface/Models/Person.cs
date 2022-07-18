using System;
using System.Collections.Generic;
using System.Text;
using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Models
{
    public class Person : IPerson
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public string GetName()
        {
            return $"{Name}";
        }
    }
}
