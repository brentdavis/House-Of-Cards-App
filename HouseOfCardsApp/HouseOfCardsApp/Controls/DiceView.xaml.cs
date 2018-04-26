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
	public partial class DiceView : ContentView
	{
		public DiceView ()
		{
			InitializeComponent ();
		}
	}
}