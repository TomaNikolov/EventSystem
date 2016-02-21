namespace EventSystem.Services.Web.Contracts
{
    using System.Collections.Generic;
    using System.Web;

    public interface IImagesService
    {
        ICollection<int> SaveImages(string name, IEnumerable<HttpPostedFileBase> files);
    }
}
