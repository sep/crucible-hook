using System.Web.Http;
using log4net;

namespace CrucibleHook.Controllers
{
    public abstract class LoggingControllerBase : ApiController
    {
        protected ILog Log { get; private set; }

        protected LoggingControllerBase()
        {
            Log = LogManager.GetLogger(GetType());
        }
    }
}