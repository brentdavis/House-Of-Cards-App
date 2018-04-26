using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HouseOfCardsApp.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiceRoll : ContentView
	{
		public DiceRoll ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty DiceNumberProperty = BindableProperty.Create(nameof(DiceNumber), typeof(String), typeof(DiceRoll), default(String), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: DiceNumberPropertyChanged);

        public static void DiceNumberPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DiceRoll)bindable;
            control.lblDiceNumber.Text = newValue.ToString();
        }

        public String DiceNumber
        {
            get
            {
                return (string)GetValue(DiceNumberProperty);
            }

            set
            {
                SetValue(DiceNumberProperty, value);
            }
        }

        public static readonly BindableProperty ColorBgProperty = BindableProperty.Create(nameof(bgColor), typeof(Xamarin.Forms.Color), typeof(DiceRoll), default(Xamarin.Forms.Color), Xamarin.Forms.BindingMode.TwoWay, propertyChanged: ColorBgPropertyChanged);

        public static void ColorBgPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (DiceRoll)bindable;           
            control.slDice.BackgroundColor = (Xamarin.Forms.Color)newValue;
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

    }
}