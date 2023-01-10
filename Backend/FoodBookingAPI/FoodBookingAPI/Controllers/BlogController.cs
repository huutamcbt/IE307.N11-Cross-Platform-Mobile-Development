using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Firebase.Auth;
using Firebase.Storage;
using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;

namespace FoodBookingAPI.Controllers
{
    public class BlogController : ApiController
    {
        Dictionary<string, object> param;
        HttpResponseMessage response;

        [Route("api/GetAllBlogs")]
        [HttpGet]
        public HttpResponseMessage GetAllBlogs()
        {
            response = new HttpResponseMessage();
            try
            {
                DataTable result = BlogRepository.GetAllBlogs();
                if(result != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    string jsonContent = JsonConvert.SerializeObject(result);
                    response.Content = new StringContent(jsonContent);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                }
                return response;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(Convert.ToString(CheckedCode.UNKNOW_ERROR));
                return response;
            }
        }

        private static string ApiKey = "AIzaSyBsa9QD3ZvUpyRuR-3mgc7_JhSbaTHGyIE";
        private static string Bucket = "elegant-skein-350903.appspot.com";
        private static string AuthEmail = "huutam@gmail.com";
        private static string AuthPassword = "123456";
        [Route("api/UploadImage")]
        [HttpGet]
        public async Task Func()
        {
            // FirebaseStorage.Put method accepts any type of stream.
            //var stream = new MemoryStream(Encoding.ASCII.GetBytes("Hello world!"));
            FileStream stream = File.Open(@"D:\archlinux.png", FileMode.Open);

            // of course you can login using other method, not just email+password
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("Drink")
                .Child("someFile.png")
                .PutAsync(stream, cancellation.Token);

            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();

            try
            {
                // error during upload will be thrown when you await the task
                Console.WriteLine("Download link:\n" + await task);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex.Message);
            }
        }
    }
}
