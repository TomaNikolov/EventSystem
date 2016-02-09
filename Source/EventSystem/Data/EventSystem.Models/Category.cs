namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Common;

    public class Category : IListedItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}