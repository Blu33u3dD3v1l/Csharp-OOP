using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotelss;
        public HotelRepository()
        {
            this.hotelss = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.hotelss.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            var some = new List<IHotel>();
            foreach (var item in hotelss)
            {
                some.Add(item);
            }
            return some;
        }

        public IHotel Select(string criteria)
        {
            var a = hotelss.FirstOrDefault(x => x.FullName == criteria);
            if (a != null)
            {
                return a;

            }
            return null;
        }
    }
}
