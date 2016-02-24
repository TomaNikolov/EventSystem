namespace EventSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Place : BaseModel<int>, IListedItem
    {
        private ICollection<Image> images;

        public Place()
        {
            this.images = new HashSet<Image>();
        }

        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string Street { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}