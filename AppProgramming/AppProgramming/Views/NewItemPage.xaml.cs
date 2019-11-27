using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppProgramming.Models;

namespace AppProgramming.Views
{
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            newitemDataPicker.MinimumDate = DateTime.Now;
            newitemDataPicker.Date = DateTime.Now;

            Item = new Item
            {
                Text = "",
                Description = "",
                
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (TaskDescription.Text != "" && TaskName.Text != "")
            {
                 MessagingCenter.Send(this, "AddItem", Item);
                            await Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Input error", "either text or description is empty, or both", "ok");
            }
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}