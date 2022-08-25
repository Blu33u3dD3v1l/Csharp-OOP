using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Core
{
    public class Controller : IController
    {

        private PlanetRepository planetRepo;


        public Controller()
        {
            this.planetRepo = new PlanetRepository();

        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var a = this.planetRepo.FindByName(planetName);
            if (a == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            var surr = a.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName);

            if (surr != null)
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            IMilitaryUnit warrior;
            if (unitTypeName == "SpaceForces")
            {
                warrior = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                warrior = new StormTroopers();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                warrior = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            a.Spend(warrior.Cost);
            a.AddUnit(warrior);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";


        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var a = this.planetRepo.FindByName(planetName);
            if (a == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else
            {
                var surr = a.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName);
                IWeapon weap;
                if (surr != null)
                {
                    throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
                }
                else
                {
                    if (weaponTypeName == "NuclearWeapon")
                    {
                        weap = new NuclearWeapon(destructionLevel);
                    }
                    else if (weaponTypeName == "BioChemicalWeapon")
                    {
                        weap = new BioChemicalWeapon(destructionLevel);
                    }
                    else if (weaponTypeName == "SpaceMissiles")
                    {
                        weap = new SpaceMissiles(destructionLevel);
                    }
                    else
                    {
                        throw new InvalidOperationException($"{weaponTypeName} still not available!");
                    }
                    a.Spend(weap.Price);
                    a.AddWeapon(weap);
                    return $"{planetName} purchased {weaponTypeName}!";
                }
            }
        }

        public string CreatePlanet(string name, double budget)
        {
            var a = this.planetRepo.FindByName(name);
            if (a != null)
            {
                return $"Planet {name} is already added!";
            }
            else
            {
                var planet = new Planet(name, budget);
                this.planetRepo.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }

        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var item in planetRepo.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(item.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }


        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planetRepo.FindByName(planetOne);
            var defender = planetRepo.FindByName(planetTwo);

            bool attackerIsNuclear = attacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = defender.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner = null;
            IPlanet looser = null;
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = attacker;
                    looser = defender;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = defender;
                    looser = attacker;
                }
                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planetRepo.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }





        public string SpecializeForces(string planetName)
        {
            var a = this.planetRepo.FindByName(planetName);
            if (a == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            else
            {
                if (!a.Army.Any())
                {
                    throw new InvalidOperationException("No units available for upgrade!");
                }
                else
                {
                    a.Spend(1.25);
                    a.TrainArmy();
                    return $"{planetName} has upgraded its forces!";
                }
            }
        }
    }
}
