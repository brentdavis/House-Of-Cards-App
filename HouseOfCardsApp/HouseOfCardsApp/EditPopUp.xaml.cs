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
	public partial class EditPopUp : Rg.Plugins.Popup.Pages.PopupPage
    {

        // Dictionary to get Color from color name.
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua },         { "Black", Color.Black },
            { "Blue", Color.Blue },         { "Fuchsia", Color.Fuchsia },
            { "Gray", Color.Gray },         { "Green", Color.Green },
            { "Lime", Color.Lime },         { "Maroon", Color.Maroon },
            { "Navy", Color.Navy },         { "Olive", Color.Olive },
            { "Purple", Color.Purple },     { "Red", Color.Red },
            { "Silver", Color.Silver },     { "Teal", Color.Teal },
            { "Gainsboro", Color.Gainsboro },       { "Orange", Color.Orange }
        };

        Dictionary<Color, string> ColorToName = new Dictionary<Color, string>
        {
            { Color.Aqua, "Aqua" },         { Color.Black, "Black" },
            { Color.Blue, "Blue" },         { Color.Fuchsia, "Fuchsia" },
            { Color.Gray, "Gray" },         { Color.Green, "Green" },
            { Color.Lime, "Lime" },         { Color.Maroon, "Maroon" },
            { Color.Navy, "Navy" },         { Color.Olive, "Olive" },
            { Color.Purple, "Purple" },     { Color.Red, "Red" },
            { Color.Silver, "Silver" },     { Color.Teal, "Teal" },
            { Color.Gainsboro, "Gainsboro" },       { Color.Orange, "Orange" }
        };

        private Player _player;
        public EditPopUp (Player player)
		{
			InitializeComponent ();
            _player = player;
            PlayerName.Text = player.playername;
            String colorName;

            colorName = ColorToName[player.bgColor];

            picker.SelectedItem = colorName;
            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }



        private async void OnClose(object sender, EventArgs e)
        {
            string colorName = picker.Items[picker.SelectedIndex];
            _player.playername = PlayerName.Text;
            _player.bgColor = nameToColor[colorName];
            await PopupNavigation.Instance.PopAsync();
            
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

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                //boxView.Color = Color.Default;
            }
            else
            {
                string colorName = picker.Items[picker.SelectedIndex];
                
                //FieldInfo colorField = typeof(Color).GetRuntimeField(colorName);
                //boxView.Color = (Color)(colorField.GetValue(null));
            }
        }

    }
}