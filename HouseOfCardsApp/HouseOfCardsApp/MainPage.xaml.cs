using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HouseOfCardsApp.Controls;

namespace HouseOfCardsApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        StackLayout parent;

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
            int number;
            Random rand = new Random();
            foreach (Player item in playerList)
            {
                number = rand.Next(21);
                if (number == 0)
                {
                    number = 1;
                }

                item.dice = "- " + number.ToString();
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
    }
}
