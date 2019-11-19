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
    public partial class PlaceOrder : ContentPage
    {
        public List<Tshirt> TshirtOrder { get; set; }

        public PlaceOrder()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var tshirt = new Tshirt();

            TshirtOrder = await App.Database.GetItemsAsync();
            BindingContext = tshirt;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var Tshirt = BindingContext as Tshirt;

            if (Tshirt != null)
            {
                await App.Database.SaveItemAsync(Tshirt);
                
            }
            //await Navigation.PushAsync(new OrderList());
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}