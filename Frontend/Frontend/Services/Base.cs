using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Frontend.Services
{
    static class Base
    {
        static string BaseURL = "http://foodbookingapi.somee.com";
        public static HttpClient client;
        static Base()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseURL)
            };
        }
}
}
