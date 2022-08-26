using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
            this.room = room;
        }
        public IRoom Room => this.room;
      

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            set {
                if(value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                this.residenceDuration = value; 
            }
        }

        public int AdultsCount
        {
            get { return this.adultCount; }
            set { 
                if(value <= 0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                this.adultCount = value;
            }

        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            set {
                if(value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber { get; private set; }

     
        public string BookingSummary()
        {
            var total = Math.Round(ResidenceDuration * room.PricePerNight, 2);
            var sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {total:F2} $");
            return sb.ToString().TrimEnd();
        }
    }
}
