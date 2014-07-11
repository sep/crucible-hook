using CrucibleHook.Models;

namespace CrucibleHook.Controllers
{
    public class InformationController : LoggingControllerBase
    {
        public void Notify(WebHookPush push)
        {
            Log.InfoFormat("Received {0} commit(s) (previous hash: {1}, current hash: {2})",
                push.TotalCommitCount,
                push.CommitHashBefore,
                push.CommitHashAfter);

            foreach (var commit in push.Commits)
            {
                Log.DebugFormat("{0} {1} ({2})",
                    commit.Id,
                    commit.Message,
                    commit.Author.Name);
            }
        }
    }
}
