using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;

using AppProgramming.Models;
using AppProgramming.Services;
using AppProgramming.Views;
using AppProgramming.ViewModels;
using Xamarin.Forms.Internals;

namespace AppProgramming.Views
{

    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        private List<CheckBox> _checkBoxes = new List<CheckBox>();

        public ItemsPage()
        {
            InitializeComponent();
            actionbutton.ImageSource = ImageSource.FromResource("AppProgramming.baseline_add_white_18dp.png");
            BindingContext = viewModel = new ItemsViewModel();
        }
        

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
           var id = checkBox.ClassId;
           MessagingCenter.Send(this, "Completed", id);

        }

        async void Button_OnClicked(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            MessagingCenter.Send(this, "DeleteItem", btn.ClassId);

        }
    }
}