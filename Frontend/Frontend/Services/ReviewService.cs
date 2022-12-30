using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;
using Frontend.Services;
using Newtonsoft.Json;

namespace Frontend.Services
{
    public static class ReviewService
    {
        public static async Task<List<Review>> GetReviewsByProductId(int productID)
        {
            try
            {
                //var reviews = await Base.client.GetStringAsync("api/getReviewByProductId/" + productID);
                //List<Review> reviewsConverted = JsonConvert.DeserializeObject<List<Review>>(reviews);
                //return reviewsConverted;

                //dữ liệu giả
                List<Review> reviews = new List<Review>();
                reviews.Add(new Review { ReviewID = 1, Content = "good", ProductID = 1, Rating = 4, UserID = 1 });
                reviews.Add(new Review { ReviewID = 1, Content = "nice", ProductID = 1, Rating = 4, UserID = 1 });
                return await Task.FromResult(reviews);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task AddReview(Review review)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(review);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/addReview", stringContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task UpdateReview(Review review)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(review);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/updateReview", stringContent);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task DeleteReview(Review review)
        {
            try
            {
                var response = await Base.client.DeleteAsync("api/deleteReview/" + review.ReviewID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}
