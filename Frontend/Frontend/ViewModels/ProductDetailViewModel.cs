using Frontend.Models;
using Frontend.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Frontend.ViewModels
{
    [QueryProperty("ProductID", "productID")]
    class ProductDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        private IList<ReviewRendered> sourse;
        public ObservableCollection<ReviewRendered> reviewList { get; private set; }
        private int productID;
        public int ProductID
        {
            get => productID;
            set
            {
                productID = value;
                initializeProduct(value);
            }
        }
        private int ratingValue = 3;
        public int RatingValue
        {
            get => ratingValue;
            set
            {
                ratingValue = value;
            }
        }
        private string reviewEntryValue = "";
        public string ReviewEntryValue
        {
            get => reviewEntryValue;
            set
            {
                reviewEntryValue = value;
            }
        }

        public ICommand AddReviewCommand { get; set; }
        public ICommand DeleteReviewCommand { get; set; }
        public async void initializeProduct(int productID)
        {
            sourse = new List<ReviewRendered>();


            Product product = await ProductService.GetProductByProductID(productID);
            Name = product.Name;
            Image = product.Image;
            Description = product.Description;
            Price = product.Price;
            OnPropertyChanged("Name");
            OnPropertyChanged("Image");
            OnPropertyChanged("Description");
            OnPropertyChanged("Price");



            await InitializeReview();


        }
        public ProductDetailViewModel()
        {
            AddReviewCommand = new Command(async () =>
            {
                await Shell.Current.DisplayAlert("a", reviewEntryValue + "\n" + ratingValue, "a");
                int userID = UserService.GetUserID();

                sourse.Insert(0, await ReviewService.AddReview(new Review { ProductID = productID, Content = reviewEntryValue, Rating = ratingValue, CreatedDate = new DateTime(), ModifiedDate = new DateTime(), UserID = userID }));

                reviewList = new ObservableCollection<ReviewRendered>(sourse);
                ratingValue = 0;
                reviewEntryValue = "";
                OnPropertyChanged("RatingValue");
                OnPropertyChanged("ReviewEntryValue");
                OnPropertyChanged("reviewList");

            });
            DeleteReviewCommand = new Command<ReviewRendered>(async (review) =>
            {
                await Shell.Current.DisplayAlert("a", review.Content + "\n" + review.Rating, "a");
                await ReviewService.DeleteReview(review.ReviewID);
            });

        }

        async Task InitializeReview()
        {
            List<ReviewRendered> reviews = await ReviewService.GetReviewsByProductId(productID);
            foreach (ReviewRendered review in reviews)
            {
                review.IsEditable = review.UserID == UserService.GetUserID();
                sourse.Add(review);
            }
            reviewList = new ObservableCollection<ReviewRendered>(sourse);
            OnPropertyChanged("reviewList");
        }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
