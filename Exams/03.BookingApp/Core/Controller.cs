using BookingApp.Core.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotelss;
        private RoomRepository rooms;
        private BookingRepository bookings;
        public Controller()
        {
            this.hotelss = new HotelRepository();
            this.rooms = new RoomRepository();
            this.bookings = new BookingRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            var curr = this.hotelss.Select(hotelName);
            if (curr != null)
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }
            IHotel hotel = new Hotel(hotelName, category);
            this.hotelss.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (this.hotelss.All().FirstOrDefault(x => x.Category == category) == default)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var orderedHotels =
                this.hotelss.All().Where(x => x.Category == category).OrderBy(x => x.Turnover).ThenBy(x => x.FullName);


            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int bookingNumber = this.hotelss.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return string.Format(OutputMessages.RoomNotAppropriate);




        }

        public string HotelReport(string hotelName)
        {
            IHotel curr = hotelss.Select(hotelName);
            if(curr == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            var sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{curr.Category} star hotel");
            sb.AppendLine($"--Turnover: {curr.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (!curr.Bookings.All().Any())
            {
                sb.AppendLine("none");
            }
            else
            {
                
                foreach (var booking in curr.Bookings.All())
                {
                    sb.AppendLine($"{booking.BookingSummary()}");
                    sb.AppendLine();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel curr = this.hotelss.Select(hotelName);
            if (curr == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            if(roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException("Incorrect room type!");
            }
            IRoom room = curr.Rooms.Select(roomTypeName);
            if(room == null)
            {
                return $"Room type is not created yet!";
            }
            if(room.PricePerNight != 0)
            {
                return "Price is already set!";
            }
            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var curr = this.hotelss.Select(hotelName);
            if(curr == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            IRoom r = curr.Rooms.Select(roomTypeName);
            if(r != null)
            {
                return "Room type is already created!";
            }
            IRoom roomm;
            if(roomTypeName == "Apartment")
            {
                roomm = new Apartment();
            }
            else if(roomTypeName == "DoubleBed")
            {
                roomm = new DoubleBed();
            }
            else if(roomTypeName == "Studio")
            {
                roomm = new Studio();
            }
            else
            {
                throw new ArgumentException("Incorrect room type!");
            }           
            curr.Rooms.AddNew(roomm);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
