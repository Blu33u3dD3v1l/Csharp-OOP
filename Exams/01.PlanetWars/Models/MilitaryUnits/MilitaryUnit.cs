using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;
   
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
          
            
        }
        public double Cost
        {
            get { return cost; }
            protected set { cost = value; }
        }


        public int EnduranceLevel => this.enduranceLevel;
       
  
     

        public void IncreaseEndurance()
        {
             this.enduranceLevel++;
            if (this.enduranceLevel > 20)
            {
                this.enduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
           
        }
    }
}
