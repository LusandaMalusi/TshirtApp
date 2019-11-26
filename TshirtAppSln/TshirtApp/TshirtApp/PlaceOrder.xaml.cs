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

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        protected  override void OnAppearing()
        {
            base.OnAppearing();
            var tshirt = new Tshirt();
            BindingContext = tshirt;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var tshirt = (Tshirt)BindingContext;

            await App.Database.SaveItemAsync(tshirt);
            await Navigation.PushAsync(new OrderList());
        }
    }
}