namespace EventSystem.Web.Infrastructure.Adapters
{
    using System;

    public class GuidAdapter : IGuidAdapter
    {
        public string NewGuid()
        {
           return Guid.NewGuid().ToString();
        }
    }
}
