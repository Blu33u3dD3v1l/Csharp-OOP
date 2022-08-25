using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
        {
            get { return planets; }
        }


        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var a = this.planets.FirstOrDefault(x => x.Name == name);
            if(a != null)
            {
                return a;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var a = this.planets.FirstOrDefault(x => x.Name == name);
            return this.planets.Remove(a);
        }
    }
}
