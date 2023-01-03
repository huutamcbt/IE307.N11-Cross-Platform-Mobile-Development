using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public class ReviewRendered :Review
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool IsEditable { get; set; }

        //public ReviewRendered( Review review, int userID, string name,string logo, bool isEditable) {
        //    this.ReviewID = review.ReviewID;
        //    this.Content = review.Content;
        //    this.Rating = review.Rating;
        //    this.ProductID = review.ProductID;
        //    this.CreatedDate = review.CreatedDate;
        //    this.ModifiedDate = review.ModifiedDate;
        //    this.Name = name;
        //    this.Logo = logo;
        //    this.IsEditable = isEditable;
            
        //}

    }
}
