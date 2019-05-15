using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TutorialWebApi.MVC
{
    public static class GlobalApiVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalApiVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:58139/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}