using System.Web.Http;

namespace Traffic.Hooks.Controllers
{
    public class WebHooksController : ApiController
    {
        public string[] Get()
        {
            return new [] { "Hello", "World" };
        }
    }
}
