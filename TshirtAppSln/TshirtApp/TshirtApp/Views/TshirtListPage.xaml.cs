using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TshirtListPage : ContentPage
    {
        public List<Tshirt>Sleeve { get; set; }

        public TshirtListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Sleeve = await App.Database.GetItemsAsync();
            BindingContext = this;
        }

       private async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TshirtItemPage
            {
                BindingContext = new Tshirt()
            });
        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TshirtItemPage
                {
                    BindingContext = e.SelectedItem as Tshirt
                });
            }
        }
    }
}
