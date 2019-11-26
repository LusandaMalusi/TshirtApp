using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class OrderList : ContentPage
    {
        public List<Tshirt> Orders { get; set; }
        public List<Tshirt> orders { get; set; }

        public OrderList()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var stuff = App.Database;
            Orders = await stuff.GetItemsAsync();
            BindingContext = this;
        }
       
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                await DisplayAlert("Connection", "Internet is working", "ok");
            }
            var databaseContent = App.Database;
            Orders = await databaseContent.GetItemsAsync();
            var MyServerOrders = Orders.Select(x => new Tshirt()
            {
                Name = x.Name,
                Gender = x.Gender,
                Tshirtsize = x.Tshirtsize,
                Datetime = x.Datetime,
                Tshirtcolor = x.Tshirtcolor,
                Shippingadress = x.Shippingadress
            });
            var json = JsonConvert.SerializeObject(MyServerOrders);
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/products";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
            }

            await Navigation.PushAsync(new OrderList());
            }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
    }

