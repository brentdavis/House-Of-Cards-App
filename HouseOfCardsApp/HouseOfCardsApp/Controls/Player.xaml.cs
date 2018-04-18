using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

namespace HouseOfCardsApp.Controls
{
   
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Player : ContentView
	{

        private int _id;

        public Player ()
		{

			InitializeComponent ();
        
            
		}

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }

        }

        //binding property to allow for editing the player name.
        public static readonly BindableProperty PlayerNameProperty = BindableProperty.Create(nameof(playername), typeof(String), typeof(Player), default(String), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: PlayerNamePropertyChanged);
        
        public static void PlayerNamePropertyChanged (BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Player) bindable;
            control.lblPlayerName.Text = newValue.ToString();
        }

        public String playername
        {
            get
            {
                return (string)GetValue(PlayerNameProperty);
            }

            set
            {
                SetValue(PlayerNameProperty, value);
            }
        }

        //Binding property to se the text for the dice rolls.
        public static readonly BindableProperty DiceProperty = BindableProperty.Create(nameof(dice), typeof(String), typeof(Player), default(String), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: DicePropertyChanged);

        public static void DicePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Player)bindable;
            control.lblDice.Text = newValue.ToString();
                 
        }

        public String dice
        {
            get
            {
                return (string)GetValue(DiceProperty);
            }

            set
            {
                SetValue(DiceProperty, value);
            }
        }

        //Binding property to track player life total.
        public static readonly BindableProperty LifeProperty = BindableProperty.Create(nameof(life), typeof(String), typeof(Player), default(String), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: LifePropertyChanged);

        public static void LifePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Player)bindable;
            control.lblLife.Text = newValue.ToString();

        }

        public String life
        {
            get
            {
                return (string)GetValue(LifeProperty);
            }

            set
            {
                SetValue(LifeProperty, value);
            }
        }

        //Binding property to track poison counters/something else.
        public static readonly BindableProperty PoisonProperty = BindableProperty.Create(nameof(poison), typeof(String), typeof(Player), default(String), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: PoisonPropertyChanged);

        public static void PoisonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Player)bindable;
            control.lblPoison.Text = newValue.ToString();

        }

        public String poison
        {
            get
            {
                return (string)GetValue(PoisonProperty);
            }

            set
            {
                SetValue(PoisonProperty, value);
            }
        }

        public static readonly BindableProperty ColorBgProperty = BindableProperty.Create(nameof(bgColor), typeof(Xamarin.Forms.Color), typeof(Player), default(Xamarin.Forms.Color), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: ColorBgPropertyChanged);

        public static void ColorBgPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Player)bindable;
            control.GrdPlayer.BackgroundColor = (Xamarin.Forms.Color)newValue;
        }

        public Xamarin.Forms.Color bgColor
        {
            get
            {
                return (Color)GetValue(ColorBgProperty);
            }

            set
            {
                SetValue(ColorBgProperty, value);
            }
        }

        async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {
            //var PlayerEdit = new PlayerEdit();

            //await this.Navigation.PushModalAsync(PlayerEdit);

           

            var _editPopUP = new EditPopUp(this);
            //await this.Navigation.PushModalAsync(_editPopUP);
            await PopupNavigation.Instance.PushAsync(_editPopUP);
        }

        int lifeTotal;
        int poisonTotal;

        private void TapGestureRecognizer_Tapped_Plus(object sender, EventArgs e)
        {
            lifeTotal = Convert.ToInt32(lblLife.Text);
            lifeTotal++;
            life = lifeTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_Minus(object sender, EventArgs e)
        {
            lifeTotal = Convert.ToInt32(lblLife.Text);
            lifeTotal--;
            life = lifeTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_PoisonAdd(object sender, EventArgs e)
        {
            poisonTotal = Convert.ToInt32(lblPoison.Text);
            poisonTotal++;
            poison = poisonTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_PoisonMinus(object sender, EventArgs e)
        {
            poisonTotal = Convert.ToInt32(lblPoison.Text);
            poisonTotal--;
            poison = poisonTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_MinusFive(object sender, EventArgs e)
        {
            lifeTotal = Convert.ToInt32(lblLife.Text);
            lifeTotal -= 5;
            life = lifeTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_PlusFive(object sender, EventArgs e)
        {
            lifeTotal = Convert.ToInt32(lblLife.Text);
            lifeTotal += 5;
            life = lifeTotal.ToString();
        }

        private void TapGestureRecognizer_Tapped_Delete(object sender, EventArgs e)
        {
            StackLayout parentLayout = (StackLayout)Parent;
            parentLayout.Children.Remove(this);
            MainPage mainpage = (MainPage)Application.Current.MainPage;
            mainpage.playerCount--;
        }
    }
}