namespace EventSystem.Services.Web.Contracts
{
    using System.Collections.Generic;
    using System.Web;

    public interface IWebImagesService
    {
        ICollection<Models.Image> SaveImages(string name, IEnumerable<HttpPostedFileBase> files);
    }
}
