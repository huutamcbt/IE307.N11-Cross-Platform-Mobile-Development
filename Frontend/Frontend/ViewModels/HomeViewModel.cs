using Frontend.Models;
using Frontend.Services;
using Frontend.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Frontend.ViewModels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        readonly IList<Product> source;
        public ObservableCollection<Product> productList { get; private set; }

        readonly IList<Category> source1;
        public ObservableCollection<Category> categoryList { get; private set; }

        readonly IList<CarouselItem> source2;
        public List<CarouselItem> carouselList { get; private set; }

        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }
        public ICommand CarouselTapCommand { get; set; }
        public HomeViewModel()
        {
            source = new List<Product>();
            source1 = new List<Category>();
            source2 = new List<CarouselItem>();

            ItemTapCommand = new Command<Product>(async (item) =>
            {
                await Shell.Current.GoToAsync($"/{nameof(ProductDetailPage)}?productID={item.ProductId}");
            });

            CatTapCommand = new Command<Category>(async (items) =>
            {
                int CategoryID = items.ID;
                await Shell.Current.GoToAsync($"/{nameof(ProductPage)}?categoryID={CategoryID}");
                //await Shell.Current.GoToAsync($"/{nameof(CategoryPage)}");
            });
            CarouselTapCommand = new Command<CarouselItem>(async (items) =>
            {
                string navigationRoute = items.NavigateRoute;
                await Shell.Current.GoToAsync(navigationRoute);
            });


            CreateItemCollection();
            CreateCategoriesCollection();
            CreateCarouselCollection();
        }

        void CreateCarouselCollection()
        {

            source2.Add(new CarouselItem { Image = "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/banner%2Fadam-jaime-dmkmrNptMpw-unsplash.jpg?alt=media&token=24393dcc-bdde-46e8-9559-9881d1f42b09", NavigateRoute = $"/{nameof(ProductPage)}" });
            source2.Add(new CarouselItem { Image = "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/banner%2Fbrooke-lark-M4E7X3z80PQ-unsplash.jpg?alt=media&token=bb71bf7f-9402-451f-8911-1c0f1b7aa850", NavigateRoute = $"/{nameof(ProductPage)}" });
            source2.Add(new CarouselItem { Image = "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/banner%2Fcharlesdeluvio-D-vDQMTfAAU-unsplash.jpg?alt=media&token=a41e9fb8-829a-4f57-8e4e-d305f60e1e20", NavigateRoute = $"/{nameof(ProductPage)}" });
            source2.Add(new CarouselItem { Image = "https://firebasestorage.googleapis.com/v0/b/elegant-skein-350903.appspot.com/o/banner%2Femy-XoByiBymX20-unsplash.jpg?alt=media&token=5416a8e4-a16e-443e-882b-a74fc1b02344", NavigateRoute = $"/{nameof(ProductPage)}" });

            carouselList = new List<CarouselItem>(source2);

        }

        async void CreateCategoriesCollection()
        {
            List<Category> categories = await CategoriesService.GetAllCategory();
            foreach (Category category in categories)
            {
                source1.Add(category);
            }
            categoryList = new ObservableCollection<Category>(source1);
        }
        async void CreateItemCollection()
        {
            List<Product> products = await ProductService.GetAllProduct();
            foreach (Product product in products)
            {
                source.Add(product);
            }
            productList = new ObservableCollection<Product>(source);
            OnPropertyChanged("productList");
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
