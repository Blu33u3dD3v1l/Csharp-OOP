namespace ExplicitInterfaces.Models
{
    using ExplicitInterfaces.Contracts;
    using System;
    using System.Text;

    public  class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country,int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public virtual string GetName()
        {
            var a = new StringBuilder();
            a.AppendLine($"{Name}");
            a.AppendLine($"Mr/Ms/Mrs {Name}");
            return a.ToString().TrimEnd();
        }

     
    }
}
