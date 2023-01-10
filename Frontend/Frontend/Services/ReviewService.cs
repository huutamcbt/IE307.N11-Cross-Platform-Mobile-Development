using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class ReviewService
    {
        public static async Task<List<Review>> GetReviewsByProductId(int ProductId)
        {
            try
            {
                var reviews = await Base.client.GetStringAsync("api/GetReviewsByProductId/" + ProductId);
                List<Review> reviewsConverted = JsonConvert.DeserializeObject<List<Review>>(reviews);
                return reviewsConverted;
          


                ////dữ liệu giả
                //List<ReviewRendered> reviews = new List<ReviewRendered>();
                //reviews.Add(new ReviewRendered { ReviewId = 1, Content = "good", ProductId = 1, Rating = 4, UserId = 1, Logo = "profile.webp", Name = "Nguyễn Văn A" });
                //reviews.Add(new ReviewRendered { ReviewId = 1, Content = "nice", ProductId = 1, Rating = 4, UserId = 2, Logo = "profile.webp", Name = "Nguyễn Văn B" });
                //return await Task.FromResult(reviews);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task<HttpResponseMessage> AddReview(Review review)
        {
            try
            {
                var json = JsonConvert.SerializeObject(review);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                var response = await Base.client.PostAsync("api/AddReview", stringContent);


                //ReviewRendered reviewRendered = new ReviewRendered
                //{
                //    ReviewId = review.ReviewId,
                //    Content = review.Content,
                //    UserId = review.UserId,
                //    ModifiedDate = review.ModifiedDate,
                //    CreatedDate = review.CreatedDate,
                //    ProductId = review.ProductId,
                //    Rating = review.Rating,
                //    Logo = "profile.webp",
                //    Name = "Nguyễn Văn A",
                //    IsEditable = true
                //};
                return response;
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
                await Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task DeleteReview(int ReviewId)
        {
            try
            {
                var response = await Base.client.DeleteAsync("api/deleteReview/" + ReviewId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
