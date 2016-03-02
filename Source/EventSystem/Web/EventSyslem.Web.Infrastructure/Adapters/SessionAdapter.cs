using System;
using System.Web;
using System.Web.SessionState;

namespace EventSystem.Web.Infrastructure.Adapters
{
    public class SessionAdapter : ISessionAdapter
    {
        public SessionAdapter(HttpSessionState session)
        {
            this.Session = new HttpSessionStateWrapper(session);
        }

        public HttpSessionStateBase Session { get; private set; }
    }
}
