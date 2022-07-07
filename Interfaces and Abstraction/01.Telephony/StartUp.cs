using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
           
            SmartPhone nums = new SmartPhone();
            var stationaryPhone = new StationaryPhone();
            var phoneNums = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();
            for (int i = 0; i < phoneNums.Length; i++)
            {
                char[] number = phoneNums[i].ToCharArray();
                if (number.Any(x => Char.IsDigit(x) == false))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    nums.PhoneNumber = phoneNums[i];
                    Console.WriteLine(nums.Caling());
                }              
            }
            for (int i = 0; i < urls.Length; i++)
            {             
                nums.Url = urls[i];
                Console.WriteLine(nums.Browsing());

            }

        }
    }
}
