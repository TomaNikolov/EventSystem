namespace EventSystem.Services.Contracts
{
    using EventSystem.Models;

    public interface IImagesService
    {
        Image Save(string name, string type, string path, string thumbnailPath);
    }
}
