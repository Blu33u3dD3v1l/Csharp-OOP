namespace ExplicitInterfaces.Contracts
{
    using ExplicitInterfaces.Models;
    public interface IResident 
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public string GetName();
    }
}
