namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string Street { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}