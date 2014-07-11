using System;
using System.Net;
using System.Web.Configuration;

namespace CrucibleHook.Controllers
{
    public class CrucibleController : LoggingControllerBase
    {
        public void Notify(string id)
        {
            try
            {
                var client = new WebClient();

                SetupHeaders(client);

                var url = BuildUrl(id);

                client.UploadData(url, "POST", new byte[0]);
            }
            catch (WebException ex)
            {
                Log.Error("Error communicating with Crucible", ex);
                throw;
            }
        }

        private static string BuildUrl(string repositoryName)
        {
            var baseUrl = WebConfigurationManager.AppSettings["CrucibleBaseUrl"];
            var notifyUrl = String.Format(WebConfigurationManager.AppSettings["CrucibleNotifyUrlFormat"], repositoryName);
            var url = baseUrl + notifyUrl;
            return url;
        }

        private static void SetupHeaders(WebClient client)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["X-Api-Key"] = WebConfigurationManager.AppSettings["ApiKey"];
        }
    }
}
