namespace EventSystem.Web.Infrastructure.Adapters
{
    using System;
    using System.Web;

    public class MapPathAdapter : IMapPathAdapter
    {
        private HttpServerUtility utility;

        public MapPathAdapter(HttpServerUtility utility)
        {
            this.utility = utility;
        }

        public string MapPath(string path)
        {
            return utility.MapPath(path);
        }
    }
}
