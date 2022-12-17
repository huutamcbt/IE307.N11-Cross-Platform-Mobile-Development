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
        public int ProductID
        {
            set
            {
                initializeProduct(value);
            }
        }
        public async void initializeProduct (int productID){
            ProductService service = new ProductService();

            Product product = await service.GetProductByProductID(productID);
            Name = product.Name;
            Image = product.Image;
            Description = product.Description;
            Price = product.Price;
            OnPropertyChanged("Name");
            OnPropertyChanged("Image");
            OnPropertyChanged("Description");
            OnPropertyChanged("Price");
        }
        public ProductDetailViewModel()
        {
            
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
