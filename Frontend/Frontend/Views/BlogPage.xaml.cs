
using Frontend.Models;
using Frontend.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Frontend.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogPage : ContentPage
    {
        private List<Blog> blogs = BlogService.GetBlogs();
        public BlogPage()
        {
            InitializeComponent();
            BlogList.ItemsSource = blogs;
        }

        private async void TapBlog_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            TapGestureRecognizer tapGesture = (TapGestureRecognizer)frame.GestureRecognizers[0];
            Blog blog = tapGesture.CommandParameter as Blog;
            await Shell.Current.Navigation.PushAsync(new BlogDetail(blog));
        }
    }
}