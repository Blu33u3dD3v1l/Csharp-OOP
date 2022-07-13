namespace WildFarm.Classes
{
    public abstract class Feline : Mammal
    {
        public string breed;
        protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }



        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
