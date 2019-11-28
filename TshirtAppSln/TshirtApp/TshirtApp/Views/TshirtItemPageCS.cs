using Xamarin.Forms;

namespace TshirtApp.Views
{
     public class TshirtItemPageCS : ContentPage
    {
        public TshirtItemPageCS()
        {
            Title = "TshirtApp";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var surnameEntry = new Entry();
            surnameEntry.SetBinding(Entry.TextProperty, "Surname");

            var genderEntry = new Entry();
            genderEntry.SetBinding(Entry.TextProperty, "gender");

            var TshirtcolorEntry = new Entry();
            TshirtcolorEntry.SetBinding(Entry.TextProperty, "Tshirtcolor");

            var TshirtsizeEntry = new Entry();
            TshirtsizeEntry.SetBinding(Entry.TextProperty, " Tshirtsize ");

            var DateTimeEntry = new Entry();
            DateTimeEntry.SetBinding(Entry.TextProperty, "DateTime");

            var ShippingadressEntry = new Entry();
            ShippingadressEntry.SetBinding(Entry.TextProperty, "Shippingadress");


            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var tshirt = (Tshirt)BindingContext;
                await App.Database.SaveItemAsync(tshirt);
                await Navigation.PopAsync();
            };
            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    saveButton,
                    cancelButton,
                }
            };
        }
    }
}

