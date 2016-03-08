namespace EventSystem.Web.Infrastructure.Adapters
{
    using System.IO;

    public class FileSaverAdapter : IFileSaverAdapter
    {
        public void WriteAllBytes(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
