namespace WildFarm.Classes
{
    public abstract class Food
    {

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public virtual int Quantity { get; set; }




    }
}
