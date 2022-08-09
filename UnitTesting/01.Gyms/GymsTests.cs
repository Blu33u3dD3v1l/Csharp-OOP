using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        
        public void correctName()
        { 

            var name = "Ivan";
            var athlete = new Athlete(name);
            Assert.That(name, Is.EqualTo(athlete.FullName));

        }
        [Test]
        public void gymNameTest()
        {
            var name = "Ivan";
            var gym= new Gym(name, 10);
            Assert.That(name, Is.EqualTo(gym.Name));
        }
        [Test]
        public void nameIsNullOrEmptyTest()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Gym(String.Empty, 2));
        }
        [Test]
        public void capacityTest()
        {          
            
                var expectedCapacity = 10;
                var shop = new Gym("Ivan", expectedCapacity);
                var currentCapacity = shop.Capacity;

                Assert.AreEqual(expectedCapacity, currentCapacity);
            
        }
        [Test]
        public void capacityTestException()
        {
            Assert.Throws<ArgumentException>(() => new Gym("ivan", -1));
        }
        [Test]
        public void countShouldReturnRightValues()
        {
            var gym = new Gym("Ivan", 0);
            Assert.AreEqual(0, gym.Count);  

        }
        [Test]
        public void addCheck()
        {
            var gym = new Gym("Ivan", 1);
            var pedal = new Athlete("Gei");
            var manaf = new Athlete("minja");
            gym.AddAthlete(pedal);
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(manaf));
        }
        [Test]
        public void correctAdd()
        {
            var gym = new Gym("Ivan", 1);
            var pedal = new Athlete("Gei");
            gym.AddAthlete(pedal);
            Assert.IsNotNull(gym.Count);
            
        }
        [Test]
        public void removeIfNullCheck()
        {
            var gym = new Gym("iva", 10);
            var athlete = new Athlete("Pesho");
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Misho"));
        }
        [Test]
        public void suxesfullRemove()
        {
            var gym = new Gym("iva", 10);
            var athlete = new Athlete("Ivan");
            gym.AddAthlete(athlete);           
            gym.RemoveAthlete(athlete.FullName);
            Assert.That(0, Is.EqualTo(gym.Count));

        }
        [Test]
        public void injuredAthlete()
        {
            var gym = new Gym("iva", 10);
            var athlete = new Athlete("Ivan");
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Gosho"));
        }
        [Test]
        public void correctInjur()
        {
            var gym = new Gym("iva", 10);
            var athlete = new Athlete("Ivan");
            gym.AddAthlete(athlete);
            var a = gym.InjureAthlete("Ivan");
            Assert.That(athlete.FullName, Is.EqualTo(a.FullName));
        }
        [Test]
        public void raport()
        {
            var gym = new Gym("iva", 3);
            var athlete = new Athlete("Ivan");
            var athhlete2 = new Athlete("Misho");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athhlete2);

            var a = gym.InjureAthlete(athlete.FullName);

            var report = gym.Report();
            Assert.AreEqual("Active athletes at iva: Misho", gym.Report());
        }






    }
}
