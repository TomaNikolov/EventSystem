namespace EventSystem.Models
{
    public class Place
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int AdressId { get; set; }

        public Adress Adress { get; set; }
    }
}