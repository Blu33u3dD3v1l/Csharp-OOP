namespace WildFarm.Classes
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, double foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name { get; private set ; }
        public double Weight { get; set; }
        public double FoodEaten { get ; set ; }

     
   

        public abstract string ProduceSound();

        
    }
}
