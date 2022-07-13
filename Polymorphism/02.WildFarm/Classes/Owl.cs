namespace WildFarm.Classes
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingsize) : base(name, weight, foodEaten, wingsize)
        {

        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
