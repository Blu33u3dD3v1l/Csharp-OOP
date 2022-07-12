using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public  double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public abstract string Area(double km);
        public abstract void Refuel(double litters);
       
    }
}
