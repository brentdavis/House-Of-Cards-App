using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseOfCardsApp.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HouseOfCardsApp
{
    
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiceRoller : ContentPage
	{
        
		public DiceRoller ()
		{
			InitializeComponent ();

            //int sides = Convert.ToInt32(txtDiceSides.Text);
            //int numbers = Convert.ToInt32(txtNumberDice.Text);
        }

        public StackLayout parent;

        private void Button_Clicked (object sender, EventArgs e)
        {
            if (parent != null)
            {
                cleanUpForm(parent);
            }
            

            if (Convert.ToInt32(txtDiceSides.Text) > 100)
            {
                txtDiceSides.Text = "100";
            }

            if (Convert.ToInt32(txtNumberDice.Text) > 20)
            {
                txtNumberDice.Text = "20";
            }

            int sides = Convert.ToInt32(txtDiceSides.Text);
            int diceNumber = Convert.ToInt32(txtNumberDice.Text);
            int number;
            Random rand = new Random();
            //String diceText = "";

            for (int i = 1; i <= diceNumber; i++)
            {
                //add new number
                DiceRoll newDice;
                newDice = new DiceRoll();

                if (i%2 == 0)
                {
                    newDice.BackgroundColor = Color.Gainsboro;
                }
                else
                {
                    newDice.BackgroundColor = Color.LightBlue;
                }

                number = rand.Next(sides + 1);
                if (number == 0)
                {
                    number = 1;
                }

                //diceText = diceText + number.ToString() + " | ";
                newDice.DiceNumber = number.ToString();

                parent = DiceLayout;
                parent.Children.Add(newDice);
            }
           

        }

        //Remove the controls before it running again
        private void cleanUpForm(StackLayout myParent) {

                     
            foreach (var item in myParent.Children.ToList())
            {
                if (item is DiceRoll)
                {
                    myParent.Children.Remove(item);
                }                 
            }
            
        }
    }
}