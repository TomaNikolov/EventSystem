namespace EventSystem.Web.Infrastructure.Adapters
{
    using System.Web;

    public interface ISessionAdapter
    {
        HttpSessionStateBase Session { get; }
    }
}
