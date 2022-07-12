using System;
using System.Linq;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            var someCar = Console.ReadLine();
            var someTruck = Console.ReadLine();
            var carTokens = someCar.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var truckTokens = someTruck.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var fq = double.Parse(carTokens[1]);
            var fc = double.Parse(carTokens[2]);
            var fqT = double.Parse(truckTokens[1]);
            var fcT = double.Parse(truckTokens[2]);




            Vehicle car = new Car(fq, fc);
            Vehicle truck = new Truck(fqT, fcT);

            var num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var cmd = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Drive")
                {
                    if (cmd[1] == "Car")
                    {
                        var km = double.Parse(cmd[2]);
                        Console.WriteLine(car.Area(km));
                        
                    }
                    else
                    {
                        var km = double.Parse(cmd[2]);
                        Console.WriteLine(truck.Area(km));
                       
                    }

                }
                else
                {
                    
                    if (cmd[1] == "Car")
                    {
                        var litters = double.Parse(cmd[2]);
                        car.Refuel(litters);
                    }
                    else
                    {

                        var litters = double.Parse(cmd[2]);
                        truck.Refuel(litters);


                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            
        }
    }
}
