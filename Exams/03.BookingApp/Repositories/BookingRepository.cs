using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            var some = new List<IBooking>();
            foreach (var item in bookings)
            {
                some.Add(item);
            }
            return some;
        }

        public IBooking Select(string criteria)
        {
            var a = bookings.FirstOrDefault(x => x.GetType().Name == criteria);
            if (a != null)
            {
                return a;

            }
            return null;
        }
    }
}
