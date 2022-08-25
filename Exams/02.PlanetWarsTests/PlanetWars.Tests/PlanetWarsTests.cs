using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {        
        public class PlanetWarsTests
        {
            [Test]
            public void priceException()
            {
                
                Assert.Throws<ArgumentException>(() => new Weapon("Ivan", -1, 20));
            }
            [Test]
            public void priceWorksProperly()
            {
                var weapon = new Weapon("Ivan", 10, 20);
                var currPrice = 10;
                var weaponPrice = weapon.Price;
                Assert.That(currPrice, Is.EqualTo(weaponPrice));

            }
            [Test]
            public void destructionLvlIncreaseWorksProperly()
            {
                var weapon = new Weapon("Ivan", 10, 0);              
                weapon.IncreaseDestructionLevel();                
                Assert.That(1, Is.EqualTo(weapon.DestructionLevel));
            }
            [Test]
            public void nuclearCheckWorksProperly()
            {
                var weapon = new Weapon("Ivan", 10, 11);
                Assert.IsTrue(weapon.IsNuclear);
            }
            [Test]
            public void planetNameTestException()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 100));
                Assert.Throws<ArgumentException>(() => new Planet(String.Empty, 100));
            }
            [Test]
            public void planetNameWorksPropperly()
            {
                
                var currName = "Ivan";
                var planet = new Planet(currName, 100);
                var expectedName = planet.Name;
                Assert.That(currName, Is.EqualTo(expectedName));
            }
            [Test]
            public void budgetWorksProperly()
            
            {

                var currBudget = 10;
                var planet = new Planet("Ivan", currBudget);
                var expecteBudget = planet.Budget;
                Assert.That(currBudget, Is.EqualTo(expecteBudget));
            }

            [Test]
            public void budgetException()

            {


                Assert.Throws<ArgumentException>(() => new Planet("Ivan", - 1));
            }
            [Test]
            public void militaryTestWorksProperly()
            {
                var list = new Planet("fdfd", 10);
                var weapon1 = new Weapon("Ivan", 100, 200);
                var weapon2 = new Weapon("Gosho", 59, 49);
                list.AddWeapon(weapon1);
                list.AddWeapon(weapon2);
                var currSum = 249;
                Assert.That(currSum, Is.EqualTo(list.MilitaryPowerRatio));


            }
            [Test]
            public void amountChechWorksProperly()
            {
                var list = new Planet("fdfd", 10);
                var amount = 100;
                var sum = list.Budget + amount; 
                list.Profit(amount);
                Assert.That(list.Budget, Is.EqualTo(sum));
            }
            [Test]
            public void addWEaponWorks()
            {
                var list = new Planet("fdfd", 10);
                var weapon = new Weapon("Gosho", 100, 200);
                list.AddWeapon(weapon);
                Assert.That(1, Is.EqualTo(list.Weapons.Count));
            }
            [Test]
            public void addWEaponException()
            {
                var list = new Planet("fdfd", 10);
                var weapon = new Weapon("Gosho", 100, 200);
                list.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => list.AddWeapon(weapon));
            }
            [Test]
            public void removeWEaponWorks()
            {
                var list = new Planet("fdfd", 10);
                var weapon = new Weapon("Gosho", 100, 200);
                list.AddWeapon(weapon);
                Assert.That(1, Is.EqualTo(list.Weapons.Count));
                list.RemoveWeapon(weapon.Name);
                Assert.That(0, Is.EqualTo(list.Weapons.Count));
            }
            [Test]
            public void upgradeWeaponException()
            {
                var list = new Planet("fdfd", 10);
                Assert.Throws<InvalidOperationException>(() => list.UpgradeWeapon("Ivan"));
            }
            [Test]
            public void upgradeWeaponWorks()
            {
                var list = new Planet("fdfd", 10);
                var weapon = new Weapon("Gosho", 100, 50);
                list.AddWeapon(weapon);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(51));

            }
            [Test]
            public void destructChechException()
            {
                var list = new Planet("fdfd", 10);
                var list1 = new Planet("dfdf", 20);
                var weapon = new Weapon("Gosho", 100, 50);
                list.AddWeapon(weapon);
                var weapon1 = new Weapon("bbobi", 100, 200);
                list1.AddWeapon(weapon1);
                var first = weapon.DestructionLevel;
                var second = weapon.DestructionLevel;
                Assert.Throws<InvalidOperationException>(() => list.DestructOpponent(list1));
            }
            [Test]
            public void destroWorksProperly()
            {
                var list = new Planet("fdfd", 10);
                var list1 = new Planet("dfdf", 20);
                var weapon = new Weapon("Gosho", 100, 200);
                list.AddWeapon(weapon);
                var weapon1 = new Weapon("bbobi", 100, 50);
                list1.AddWeapon(weapon1);
                Assert.That(weapon.DestructionLevel, Is.GreaterThan(weapon1.DestructionLevel));
            }
            [Test]
            public void weaponNameWorks()
            {
                var currName = "Ivan";
                var weapon = new Weapon(currName,10, 100);
                Assert.That(weapon.Name, Is.EqualTo(currName));
            }
            [Test]
            public void DestructOpponentShoudReturnCorrectString()
            {
                Planet attacker = new Planet("Mars", 100.5);
                Planet defender = new Planet("Earth", 200.3);

                attacker.AddWeapon(new Weapon("Gun", 15.8, 50));
                attacker.AddWeapon(new Weapon("Laser", 117.2, 60));

                defender.AddWeapon(new Weapon("Laser", 117.2, 40));
                defender.AddWeapon(new Weapon("WaterGun", 117.2, 30));

                string resultMessage = attacker.DestructOpponent(defender);
                Assert.AreEqual("Earth is destructed!", resultMessage);
            }
            [Test]
            public void SpendFundsShouldThrowExceptionIfNotEnoughBudget()
            {
                Planet planet = new Planet("Mars", 100.5);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(150.2));
            }
            [Test]
            public void SpendFundsShouldDecreseBudget()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.SpendFunds(50.5);
                Assert.AreEqual(50, planet.Budget);
            }
            [Test]
            public void ProfitMethodShouldWorkProperly()
            {
                Planet planet = new Planet("Mars", 100.5);
                planet.Profit(15.5);
                Assert.AreEqual(116, planet.Budget);
            }



        }
    }
}
