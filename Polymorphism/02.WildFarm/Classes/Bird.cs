namespace WildFarm.Classes
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }
        protected Bird(string name, double weight, double foodEaten , double wingsize) : base(name, weight, foodEaten)
        {
            WingSize = wingsize;
        }
     
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
