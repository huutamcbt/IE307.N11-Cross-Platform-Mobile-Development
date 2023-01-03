using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FoodBookingAPI.Models;
using FoodBookingAPI.Repository;
using Newtonsoft.Json;

namespace FoodBookingAPI.Controllers
{
    public class ReviewController : ApiController
    {
        Dictionary<string, object> param;

        [Route("api/GetReviewsByProductId/{ProductId}")]
        [HttpGet]
        public IHttpActionResult GetReviewsByProductId(int ProductId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                param.Add(nameof(Reviews.ProductId), ProductId);

                DataTable result = ReviewRepository.GetReviewsByProductId(param);

                if (result != null)
                    return Ok(result);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/AddReview")]
        [HttpPost]
        public IHttpActionResult AddReview()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                string content = Request.Content.ReadAsStringAsync().Result;

                string jsonContent = "[" + content + "]";

                Reviews newReview = JsonConvert.DeserializeObject<List<Reviews>>(jsonContent)[0];

                param.Add(nameof(Reviews.ProductId), newReview.ProductId);
                param.Add(nameof(Reviews.Rating), newReview.Rating);
                param.Add(nameof(Reviews.UserId), newReview.UserId);
                param.Add(nameof(Reviews.Content), newReview.Content);
                param.Add(nameof(Reviews.CreatedDate), newReview.CreatedDate);
                param.Add(nameof(Reviews.ModifiedDate), newReview.ModifiedDate);
                param.Add(nameof(Reviews.DeletedDate), newReview.DeletedDate);

                bool success = ReviewRepository.AddReview(param);
                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/UpdateReview")]
        [HttpPost]
        public IHttpActionResult UpdateReview()
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                string content = Request.Content.ReadAsStringAsync().Result;
                string jsonContent = "[" + content + "]";
                Reviews updateReview = JsonConvert.DeserializeObject<List<Reviews>>(jsonContent)[0];

                param.Add(nameof(Reviews.ReviewId), updateReview.ReviewId);
                param.Add(nameof(Reviews.ProductId), updateReview.ProductId);
                param.Add(nameof(Reviews.Rating), updateReview.Rating);
                param.Add(nameof(Reviews.UserId), updateReview.UserId);
                param.Add(nameof(Reviews.Content), updateReview.Content);
                param.Add(nameof(Reviews.CreatedDate), updateReview.CreatedDate);
                param.Add(nameof(Reviews.ModifiedDate), updateReview.ModifiedDate);
                param.Add(nameof(Reviews.DeletedDate), updateReview.DeletedDate);

                bool success = ReviewRepository.UpdateReview(param);
                if (success == true)
                    return Ok();
                return NotFound();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("api/DeleteReview/{ReviewId}")]
        [HttpDelete]
        public IHttpActionResult DeleteReview(int ReviewId)
        {
            try
            {
                param = null;
                param = new Dictionary<string, object>();

                param.Add(nameof(Reviews.ReviewId), ReviewId);

                bool success = ReviewRepository.DeleteReview(param);

                if (success == true)
                    return Ok();
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
