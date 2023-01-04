using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Frontend.Services
{
    static class Base
    {
        static string BaseURL = "http://192.168.0.158/FoodBookingAPI/";
        public static HttpClient client;
        static Base()
        {

            HttpClientHandler insecureHandler = GetInsecureHandler();
            client = new HttpClient(insecureHandler);
            client.BaseAddress = new Uri(BaseURL);
        }

        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
