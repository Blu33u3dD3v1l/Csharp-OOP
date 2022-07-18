using System;
using System.Collections.Generic;
using System.Text;
using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Models
{
    public  class Resident : IResident
    {
        public Resident(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }

        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName()
        {
            return $"Mr / Ms / Mrs {Name}";
        }
    }
}
