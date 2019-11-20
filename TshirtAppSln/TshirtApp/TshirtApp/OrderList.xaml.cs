using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class OrderList : ContentPage
    {
        public List<Tshirt> Orders { get; set; }

        public OrderList()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Orders = await App.Database.GetItemsAsync();

            BindingContext = this;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var results = await DisplayAlert("hello Vinqi", "Are you sure you want to Delete?", "Yes", "No");
             if (results)
            {
                var MyTappedItem = e.Item as Tshirt;
                await App.Database.DeleteItemAsync(MyTappedItem);

                await Navigation.PushAsync(new OrderList());
            }
        }
    }
}