using Frontend.Services;

namespace Frontend.Models
{
    public class ReviewRendered : Review
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool IsEditable { get; set; }

        public ReviewRendered(Review review , User user)
        {
            this.Content = review.Content;
            this.ProductId = review.ProductId;
            this.Rating = review.Rating;
            this.ReviewId = review.ReviewId;
            this.UserId = review.UserId;
            this.CreatedDate = review.CreatedDate;
            this.DeletedDate = review.DeletedDate;
            this.ModifiedDate = review.ModifiedDate;
            this.Name = user.FirstName + " " + user.LastName;
            this.Logo = user.Logo;
            this.IsEditable = UserService.GetUserId() == review.UserId;
        }
        //public ReviewRendered( Review review, int UserId, string name,string logo, bool isEditable) {
        //    this.ReviewId = review.ReviewId;
        //    this.Content = review.Content;
        //    this.Rating = review.Rating;
        //    this.ProductId = review.ProductId;
        //    this.CreatedDate = review.CreatedDate;
        //    this.ModifiedDate = review.ModifiedDate;
        //    this.Name = name;
        //    this.Logo = logo;
        //    this.IsEditable = isEditable;

        //}

    }
}
