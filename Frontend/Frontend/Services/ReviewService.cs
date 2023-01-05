using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public static class ReviewService
    {
        public static async Task<List<ReviewRendered>> GetReviewsByProductId(int productID)
        {
            try
            {
                //var reviews = await Base.client.GetStringAsync("api/getReviewByProductId/" + productID);
                //List<ReviewRendered> reviewsConverted = JsonConvert.DeserializeObject<List<Review>>(reviews);
                //return reviewsConverted;

                //dữ liệu giả
                List<ReviewRendered> reviews = new List<ReviewRendered>();
                reviews.Add(new ReviewRendered { ReviewID = 1, Content = "good", ProductID = 1, Rating = 4, UserID = 1, Logo = "profile.webp", Name = "Nguyễn Văn A" });
                reviews.Add(new ReviewRendered { ReviewID = 1, Content = "nice", ProductID = 1, Rating = 4, UserID = 2, Logo = "profile.webp", Name = "Nguyễn Văn B" });
                return await Task.FromResult(reviews);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static async Task<ReviewRendered> AddReview(Review review)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(review);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/addReview", stringContent);


                ReviewRendered reviewRendered = new ReviewRendered
                {
                    ReviewID = review.ReviewID,
                    Content = review.Content,
                    UserID = review.UserID,
                    ModifiedDate = review.ModifiedDate,
                    CreatedDate = review.CreatedDate,
                    ProductID = review.ProductID,
                    Rating = review.Rating,
                    Logo = "profile.webp",
                    Name = "Nguyễn Văn A",
                    IsEditable = true
                };
                return await Task.FromResult(reviewRendered);
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
        public static async Task DeleteReview(int reviewID)
        {
            try
            {
                var response = await Base.client.DeleteAsync("api/deleteReview/" + reviewID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
