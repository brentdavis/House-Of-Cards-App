using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HouseOfCardsApp.Controls;

namespace HouseOfCardsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditGameSettings : Rg.Plugins.Popup.Pages.PopupPage
    {
        private MainPage _main;
		public EditGameSettings (MainPage main)
		{
            
			InitializeComponent ();
            _main = main;

            txtDiceSize.Text = _main.diceSize;
            dicePicker.SelectedItem = _main.diceNumber;
            //to do: get values coming in. save method
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return Content.FadeTo(.5);
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            //save method

            if (Convert.ToInt32(txtDiceSize.Text) > 100)
            {
                txtDiceSize.Text = "100";
            }
            _main.diceSize = txtDiceSize.Text;
            _main.diceNumber = dicePicker.Items[dicePicker.SelectedIndex];
            await PopupNavigation.Instance.PopAsync();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                //boxView.Color = Color.Default;
            }
            else
            {
                //string colorName = picker.Items[picker.SelectedIndex];

                //FieldInfo colorField = typeof(Color).GetRuntimeField(colorName);
                //boxView.Color = (Color)(colorField.GetValue(null));
            }
        }
    }
}