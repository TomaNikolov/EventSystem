namespace EventSystem.Services.Web.Contracts
{
    using System.Collections.Generic;
    using System.Web;

    public interface IWebImagesService
    {
        ICollection<int> SaveImages(string name, IEnumerable<HttpPostedFileBase> files);
    }
}
