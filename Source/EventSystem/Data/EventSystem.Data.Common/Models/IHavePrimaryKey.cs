namespace EventSystem.Data.Common.Models
{
    public interface IHavePrimaryKey<TKey> 
    {
        TKey Id { get; set; }
    }
}
