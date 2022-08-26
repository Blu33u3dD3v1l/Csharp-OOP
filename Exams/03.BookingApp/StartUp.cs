namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
