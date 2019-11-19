using System;
using Xamarin.Forms;


namespace TshirtApp
{
    public partial class TshirtItemPage : ContentPage
    {
        public TshirtItemPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var tshirt = new Tshirt();
            BindingContext = tshirt;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var tshirt = (Tshirt)BindingContext;
            await App.Database.SaveItemAsync(tshirt);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
