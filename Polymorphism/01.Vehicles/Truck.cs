using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Area(double km)
        {
            var area = (1.6 * km) + (km * FuelConsumption);

            if (this.FuelQuantity - area > 0)
            {
                this.FuelQuantity -= area;
                return $"Truck travelled {km} km";

            }
            return $"Truck needs refueling";
        }

        public override void Refuel(double litters)
        {
            var area = (litters * 5) / 100;
            litters -= area;
            FuelQuantity += litters;
        }
    }
}
