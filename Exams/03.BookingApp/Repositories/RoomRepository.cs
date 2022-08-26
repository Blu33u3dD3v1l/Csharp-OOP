using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;
        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }
        public void AddNew(IRoom room)
        {
           this.rooms.Add(room);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            var some = new List<IRoom>();
            foreach (var item in rooms)
            {
                some.Add(item);
            }
            return some;
        }

        public IRoom Select(string criteria)
        {
            var a = rooms.FirstOrDefault(x => x.GetType().Name == criteria);
            if(a != null)
            {
                return a;

            }
            return null;
        }
    }
}
