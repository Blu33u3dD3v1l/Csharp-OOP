using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void bedCapacityExc()
        {   
            Assert.Throws<ArgumentException>(() => new Room(-1, 100)); 
           
        }
        [Test]
        public void priceExc()
        {
            Assert.Throws<ArgumentException>(() => new Room(2, -1));
        }
        [Test]
        public void nameExc()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 100));
            Assert.Throws<ArgumentNullException>(() => new Hotel(String.Empty, 100));
        }

        [Test]
        public void category()
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Ivan", 0));
            Assert.Throws<ArgumentException>(() => new Hotel("Ivan", 6));
        }
        [Test]
        public void addRoom()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            Assert.That(1, Is.EqualTo(hotel.Rooms.Count));  
        }
        [Test]
        public void bookRoomAdult()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 5, 100));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 5, 100));
        }
        [Test]
        public void bookRoomChild()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 5, 100));
        }
        [Test]
        public void bookRoomDuration()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, 0, 100));
        }
        [Test]
        public void bookintTest()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 200);
            Assert.That(1, Is.EqualTo(hotel.Bookings.Count));
        }
        [Test]
        public void turnOver()
        {
            var hotel = new Hotel("Ivan Ivanov", 5);
            var room = new Room(5, 50);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 200);
            Assert.That(hotel.Turnover, Is.GreaterThan(0));
            
        }







    }
}