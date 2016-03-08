namespace EventSystem.Web.Infrastructure.Adapters
{
    public interface IFileSaverAdapter
    {
        void WriteAllBytes(string path, byte[] bytes);
    }
}
