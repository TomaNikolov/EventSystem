namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Category : BaseModel<int>, IListedItem
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}