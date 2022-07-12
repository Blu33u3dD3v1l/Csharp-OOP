using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Area(double km)
        {
            var area = (0.9 * km) + (km * FuelConsumption);
            if (this.FuelQuantity - area > 0)
            {
                this.FuelQuantity -= area;
                return $"Car travelled {km} km";

            }
            return $"Car needs refueling";
        }

        public override void Refuel(double litters)
        {
            this.FuelQuantity += litters;
        }
    }
}
