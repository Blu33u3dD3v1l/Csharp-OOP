using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }
        public double Price
        {
            get { return price; }
            protected set { price = value; }
        }
        

        public int DestructionLevel
        {
            get { return this.destructionLevel; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                if (value > 10)
                {
                    throw new ArgumentException("Destruction level cannot exceed 10 power points.");
                }

                this.destructionLevel = value;
            }
        }
    }
}
