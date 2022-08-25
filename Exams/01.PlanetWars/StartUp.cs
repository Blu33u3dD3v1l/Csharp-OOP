using PlanetWars.Core;
using System;
using System.Globalization;
using System.Threading;

namespace PlanetWars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

            engine.Run();
        }
    }
}
