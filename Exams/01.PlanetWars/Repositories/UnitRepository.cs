using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    internal class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get { return units; }
        }

        public void AddItem(IMilitaryUnit model)
        {
            this.units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var a = this.units.FirstOrDefault(x => x.GetType().Name == name);
            if(a != null)
            {
                return a;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var a = this.units.FirstOrDefault(x => x.GetType().Name == name);
            return this.units.Remove(a);
        }
    }
}
