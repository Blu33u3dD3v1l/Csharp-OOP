using System;
using System.Collections.Generic;
using System.Text;

namespace Tst
{
    public class Product
    {
        private string name;
        private int cost;

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
           
        }

        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                   
                }
                this.name = value; 
                }
        }
        public int Cost
        {
            get { return cost; }
            set {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                    
                }
                this.cost = value;
                }
        }
       
    }
}
