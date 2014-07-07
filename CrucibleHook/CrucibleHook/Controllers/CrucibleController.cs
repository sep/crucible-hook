using System;
using System.Collections.Specialized;
using System.Net;
using System.Web.Configuration;
using System.Web.Http;

namespace CrucibleHook.Controllers
{
    public class CrucibleController : ApiController
    {
        public void Notify(string id)
        {
            var client = new WebClient();

            SetupHeaders(client);

            var url = BuildUrl(id);

            client.UploadData(url, "POST", new byte[0]);
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
