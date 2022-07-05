using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {
          
          
                var a = double.Parse(Console.ReadLine());
                var b = double.Parse(Console.ReadLine());
                var c = double.Parse(Console.ReadLine());
                var box = new Box(a, b, c);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            

        }
    }
}
