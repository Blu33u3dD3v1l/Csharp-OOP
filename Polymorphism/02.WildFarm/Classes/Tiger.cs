namespace WildFarm.Classes
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
