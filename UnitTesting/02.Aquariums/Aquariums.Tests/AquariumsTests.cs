namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AquariumsTests
    {
        [Test]

        public void fishNameTest()
        {
            var currName = "Ivan";
            var fish = new Fish(currName);
            var expectedName = fish.Name;
            Assert.That(currName, Is.EqualTo(expectedName));
        }
        [Test]

        public void aquariumNameWorksProperly()
        {
            var currName = "Ivan";
            var aquarium = new Aquarium(currName, 10);
            var expectedName = aquarium.Name;
            Assert.That(currName, Is.EqualTo(expectedName));
        }

        [Test]
        public void aquariumNameException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 10));

        }
        [Test]

        public void capacityWorkProperly()
        {
            var currCap = 10;
            var aquarium = new Aquarium("Ivan", currCap);
            var expected = aquarium.Capacity;
            Assert.That(currCap, Is.EqualTo(expected));
        }
        [Test]
        public void capacotyWorkException()
        {
            Assert.Throws < ArgumentException > (() => new Aquarium("Ivan", -1));
        }
        [Test]
        public void countShouldReturnRightValues()
        {
            var aquarium = new Aquarium("Ivan", 10);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);

            var actual = aquarium.Count;
            var exspected = 1;
            Assert.AreEqual(exspected, actual);

        }
        [Test]
        public void addException()
        {
            var aquarium = new Aquarium("Ivan", 0);
            var fish = new Fish("Gosho");
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }
        [Test]
        public void removeException()
        {
            var aquarium = new Aquarium("Ivan", 10);
            var fish = new Fish("Koko");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nisho"));
        }
        [Test]
        public void removeWorkProperly()
        {
            var aquarium = new Aquarium("Ivan", 10);
            var fish = new Fish("Gosho");
            var fish1 = new Fish("Pesho");           
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.RemoveFish(fish.Name);
            Assert.That(1, Is.EqualTo(aquarium.Count));
            aquarium.RemoveFish(fish1.Name);
            Assert.That(0, Is.EqualTo(aquarium.Count));


        }
        [Test]
        public void sellFishTrowsExceptionWhenThereIsNoFishToSell()
        {
            var aquarium = new Aquarium("Ivan", 10);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Misho"));
        }
        [Test]
        public void sellingExistingFish()
        {
            var aquarium = new Aquarium("Ivan", 10);
            var fish = new Fish("Gosho");
            var fish1 = new Fish("Pesho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            var a = aquarium.SellFish(fish.Name);
            Assert.IsFalse(a.Available);

        }
        [Test]
        public void raport()
        {
            var aquarium = new Aquarium("iva", 3);
            var fish = new Fish("Ivan");
            var fish2 = new Fish("Misho");
            var fish3 = new Fish("Pepi");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.SellFish(fish.Name);
            aquarium.RemoveFish(fish.Name);
            var list = new List<string>();
            list.Add(fish2.Name);
            list.Add(fish3.Name);
            var raport = aquarium.Report();
            Assert.AreEqual($"Fish available at iva: {string.Join(", ",list)}", aquarium.Report());
        }

    }
}
