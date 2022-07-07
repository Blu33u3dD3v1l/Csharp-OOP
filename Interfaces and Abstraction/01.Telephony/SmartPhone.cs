using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interface;
using System.Linq;

namespace Telephony
{
    public class SmartPhone : ICalling,IBrowsing
    {
        private string phoneNumber;
        private string url;
        
     

      public SmartPhone()
        {
            this.PhoneNumber = phoneNumber;
            this.Url = url;       
        }
      
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { this.phoneNumber = value; }
           
        }
        public string Url
        {
            get { return url; }
            set { this.url = value; }
        }
        public string Browsing()
        {
            var a = url.Where(char.IsDigit).ToArray();
            if (a.Any())
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }
        public string Caling()
        {
          
            if (this.PhoneNumber.Count() == 10)
            {
                return $"Calling... {PhoneNumber}";
            }         
             return $"Dialing... {PhoneNumber}";
        }

    }
}
