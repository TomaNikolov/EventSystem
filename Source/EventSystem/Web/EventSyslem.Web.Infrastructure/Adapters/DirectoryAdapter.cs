namespace EventSystem.Web.Infrastructure.Adapters
{
    using System.IO;

    public class DirectoryAdapter : IDirectoryAdapter
    {
        public void Create(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
