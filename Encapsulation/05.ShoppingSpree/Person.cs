using System;
using System.Collections.Generic;
using System.Text;

namespace Tst
{
    public class Person
    {
        private string name;
        private double money;
        List<string> bagOfProducts;


        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<string>();
             
           
        }

        public string Name
        {
            get { return name; }

             set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                    
                }
                this.name = value;
            }
        }
        public double Money
        {
            get { return money; }

           set { 
                if(value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                    
                }
                this.money = value;
                }
        }
       public List<string> BagOfProducts
        {
            get { return bagOfProducts; }
            set
            {
                this.bagOfProducts = value;
            }

        }    

    }
}
