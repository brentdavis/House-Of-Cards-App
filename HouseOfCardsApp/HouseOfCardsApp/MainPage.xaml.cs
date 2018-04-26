using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HouseOfCardsApp.Controls;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

namespace HouseOfCardsApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        StackLayout parent;

        public String diceSize = "20";
        public String diceNumber = "1";
        public int playerCount = 0;
        private int playerNumber = 0;

        public ArrayList playerList = new ArrayList();

        private void TapGestureRecognizer_Add_Player(object sender, EventArgs e)
        {
            
            
            if (playerCount < 8)
            {
            playerNumber++;
            playerCount++;
            Player newPlayer;

            newPlayer = new Player();

            newPlayer.id = playerCount;

            newPlayer.playername = "Player" + playerNumber;

            parent = LifeCounterLayout;

            newPlayer.life = "20";

            newPlayer.bgColor = Xamarin.Forms.Color.Blue;

            parent.Children.Add(newPlayer);

            playerList.Add(newPlayer);

            newPlayer.poison = "0";
            }
        }

        private void TapGestureRecognizer_Tapped_Roll(object sender, EventArgs e)
        {
            
            int _diceSize = Convert.ToInt32(diceSize);
            int number;
            String diceText = "";
            int _diceNumber = Convert.ToInt32(diceNumber);
            Random rand = new Random();
            foreach (Player item in playerList)
            {
                diceText = "";
                for (int i = 1; i <= _diceNumber; i++)
                {
                    number = rand.Next(_diceSize + 1);
                    if (number == 0)
                    {
                        number = 1;
                    }

                    diceText = diceText +  number.ToString()  + " | " ;
                }
                item.dice = ": " + diceText.Substring(0, diceText.Length -2);
            }
        }

        private void TapGestureRecognizer_Tapped_Reset(object sender, EventArgs e)
        {
            foreach (Player item in playerList)
            {
                item.life = "20";
                item.poison = "0";
                item.dice = "";
            }
        }

        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {

            var _editGameSet = new EditGameSettings(this);
            await PopupNavigation.Instance.PushAsync(_editGameSet);
        }

        private void MenuItemLC_Activated(object sender, EventArgs e)
        {

        }

        private async void MenuItemDR_Activated(object sender, EventArgs e)
        {
            var nextPage = new DiceRoller();
            await this.Navigation.PushAsync(nextPage);
        }
    }
}
