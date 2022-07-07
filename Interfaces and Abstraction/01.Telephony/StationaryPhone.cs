using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interface;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {

        public string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }

        }
        public string Caling()
        {
            if (this.PhoneNumber.Count() == 10)
            {
                return $"Calling... {phoneNumber}";
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
