using System.Web.Http;
using CrucibleHook.Models;
using log4net;

namespace CrucibleHook.Controllers
{
    public class InformationController : ApiController
    {
        private readonly ILog log;

        public InformationController()
        {
            log = LogManager.GetLogger(GetType());
        }

        public void Notify(WebHookPush push)
        {
            log.InfoFormat("Received {0} commit(s) (previous hash: {1}, current hash: {2})",
                push.TotalCommitCount,
                push.CommitHashBefore,
                push.CommitHashAfter);

            foreach (var commit in push.Commits)
            {
                log.DebugFormat("{0} {1} ({2})",
                    commit.Id,
                    commit.Message,
                    commit.Author.Name);
            }
        }
    }
}
