using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogDetail : ContentPage
    {
        public BlogDetail(Blog blog)
        {
            InitializeComponent();
            BindingContext = blog;
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = blog.Content;
            Browser.Source = htmlSource;
            this.Title = blog.Title;
        }
    }
}