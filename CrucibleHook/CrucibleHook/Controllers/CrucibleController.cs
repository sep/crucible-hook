using System;
using System.Collections.Specialized;
using System.Net;
using System.Web.Configuration;
using System.Web.Http;
using CrucibleHook.Models;

namespace CrucibleHook.Controllers
{
    public class CrucibleController : ApiController
    {
        public void Notify(string id, WebHookPush push)
        {
            var client = new WebClient();

            SetupHeaders(client);

            var url = BuildUrl(id);

            client.UploadValues(url, "POST", new NameValueCollection());
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
