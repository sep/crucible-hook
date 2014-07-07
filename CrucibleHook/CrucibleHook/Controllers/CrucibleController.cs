using System;
using System.Collections.Specialized;
using System.Net;
using System.Web.Configuration;
using System.Web.Http;

namespace CrucibleHook.Controllers
{
    public class CrucibleController : ApiController
    {
        /// <summary>
        /// test
        /// </summary>
        /// <remarks>
        /// GET api/crucible/jenkins-test
        /// </remarks>
        /// <param name="id">The name of the Crucible repository to notify</param>
        [HttpGet]
        public void Notify(string id)
        {
            var client = new WebClient();

            SetupHeaders(client);

            var url = BuildUrl(id);

            client.UploadValues(url, "POST", new NameValueCollection());
        }

        /// <summary>
        /// Builds the URL.
        /// </summary>
        /// <param name="repositoryName">Name of the repository in Crucible.</param>
        /// <returns>A formatted URL.</returns>
        private static string BuildUrl(string repositoryName)
        {
            var baseUrl = WebConfigurationManager.AppSettings["CrucibleBaseUrl"];
            var notifyUrl = String.Format(WebConfigurationManager.AppSettings["CrucibleNotifyUrlFormat"], repositoryName);
            var url = baseUrl + notifyUrl;
            return url;
        }

        /// <summary>
        /// Setups the headers for the request.
        /// </summary>
        /// <param name="client">The client.</param>
        private static void SetupHeaders(WebClient client)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["X-Api-Key"] = WebConfigurationManager.AppSettings["ApiKey"];
        }
    }
}
