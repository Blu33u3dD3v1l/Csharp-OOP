using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new List<IWeapon>();
            this.army = new List<IMilitaryUnit>();          

        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get { return this.budget; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => Suming();
        
        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get { return army; }
        }


        public IReadOnlyCollection<IWeapon> Weapons
        {
            get { return weapons; }
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            var weps = new List<string>();
            var troops = new List<string>();
            var sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            foreach (var item in this.Army)
            {
                if (this.Army.Any())
                {
                    troops.Add(item.GetType().Name);
                }
            }
            foreach (var item in this.Weapons)
            {
                if (this.Weapons.Any())
                {
                    weps.Add(item.GetType().Name);
                }
            }
            if (troops.Any())
            {
                sb.AppendLine($"--Forces: {string.Join(", ",troops)}");
            }
            else
            {
                sb.AppendLine($"--Forces: No units");
            }
            if (weps.Any())
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ",weps)}");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: No weapons");
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            else
            {
                this.Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            foreach (var item in Army)
            {
                item.IncreaseEndurance();
            }
        }
        public double Suming()
        {

            double total = this.Weapons.Sum(w => w.DestructionLevel) + this.Army.Sum(u => u.EnduranceLevel);

            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                total *= 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                total *= 1.45;
            }

            return Math.Round(total, 3);
        }
    }
}
