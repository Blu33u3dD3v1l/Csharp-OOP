namespace WildFarm.Classes
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingsize) : base(name, weight, foodEaten, wingsize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
