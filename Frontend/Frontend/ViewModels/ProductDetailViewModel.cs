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
    [QueryProperty("ProductId", "ProductId")]
    class ProductDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        private IList<ReviewRendered> sourse;
        public ObservableCollection<ReviewRendered> reviewList { get; private set; }
        private int ProductId;
        public int ProductId
        {
            get => ProductId;
            set
            {
                ProductId = value;
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
        public async void initializeProduct(int ProductId)
        {
            sourse = new List<ReviewRendered>();


            Product product = await ProductService.GetProductByProductId(ProductId);
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
                int UserId = UserService.GetUserId();
                Review review = new Review
                {
                    ProductId = ProductId,
                    Content = reviewEntryValue,
                    Rating = ratingValue,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserId = UserId,
                    DeletedDate =DateTime.Now
                };
                var reponse = await ReviewService.AddReview(review);

                if ( reponse.IsSuccessStatusCode)
                {
                    User user = await UserService.GetUser();
                    sourse.Insert(0, new ReviewRendered (review, user));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Thông báo", "Thêm đánh giá thất bại", "ok");
                }


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
                await ReviewService.DeleteReview(review.ReviewId);
            });

        }

        async Task InitializeReview()
        {
            List<Review> reviews = await ReviewService.GetReviewsByProductId(ProductId);


            foreach (Review review in reviews)
            {
                User user = await UserService.GetUserById(review.UserId);
                
                sourse.Add(new ReviewRendered (review,user));
            }
            reviewList = new ObservableCollection<ReviewRendered>(sourse);
            OnPropertyChanged("reviewList");
        }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
