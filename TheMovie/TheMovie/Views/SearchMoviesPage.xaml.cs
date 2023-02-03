using System.Collections.Generic;
using System.Linq;
using TheMovie.Models;
using TheMovie.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheMovie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchMoviesPage : ContentPage
    {        
        public SearchMoviesPage()
        {
            InitializeComponent();            

            ItemsListView.ItemSelected += (sender, e) => {
                // Manually deselect item
                ((ListView)sender).SelectedItem = null;
            };

            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                SearchBar.HeightRequest = 40;
            }

            List<Genre> listGenre = new GetGenreDropDownModel().genreLists.ToList();
            PickerGenre.ItemsSource = listGenre.Select(a => a.Name).ToList();
            PickerGenre.SelectedItem = listGenre.Select(a => a.Id).ToList();
        }        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (string.IsNullOrEmpty(SearchBar.Text))
            {
                SearchBar.Focus();
            }            
        }        
    }
}