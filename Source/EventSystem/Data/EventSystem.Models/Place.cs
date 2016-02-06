namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(400)]
        public string Venue { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int AdressId { get; set; }

        public Adress Adress { get; set; }
    }
}