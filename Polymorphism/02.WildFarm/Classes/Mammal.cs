namespace WildFarm.Classes
{
    public abstract class Mammal : Animal
    {
        public string livingRegion;

        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }

        public abstract override string ToString();
    

    }
}
