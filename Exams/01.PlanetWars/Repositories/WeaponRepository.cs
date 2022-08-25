using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
       
        private List<IWeapon> weapons;
        
        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models
        {
            get { return weapons; }
        }

        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var curr = this.weapons.FirstOrDefault(x => x.GetType().Name == name);
            if(curr != null)
            {
                return curr;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var a = this.weapons.FirstOrDefault(x => x.GetType().Name == name);
            return this.weapons.Remove(a);
        }
    }
}
