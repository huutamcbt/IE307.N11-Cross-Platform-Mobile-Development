using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Frontend.Models;
using Frontend.Views;
using Xamarin.Forms;
using Frontend.Services;
namespace Frontend.ViewModels
{
    [QueryProperty("ProductID", "productID")]
    class ProductDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        private IList<Review> sourse;
        public ObservableCollection<Review> reviewList { get; private set; }
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
        private int ratingValue =3;
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

        public ICommand addReviewCommand { get;  set; }
        public async void initializeProduct(int productID)
        {
            sourse = new List<Review>();


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
            addReviewCommand = new Command(async () =>
            {
                await Shell.Current.DisplayAlert("a", reviewEntryValue + "\n" + ratingValue, "a");
                int userID = UserService.GetUserID();

                await ReviewService.AddReview(new Review {ProductID = productID,Content=reviewEntryValue,Rating = ratingValue, CreatedDate = new DateTime(),ModifiedDate= new DateTime(), UserID=userID });

            });

        }

        async Task InitializeReview()
        {
            List<Review> reviews = await ReviewService.GetReviewsByProductId(productID);
            foreach (Review review in reviews)
            {
                sourse.Add(review);
            }
            reviewList = new ObservableCollection<Review>(sourse);
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
