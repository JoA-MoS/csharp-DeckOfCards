using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Deck main = new Deck();
        public BaseCardSet table = new BaseCardSet();
        public int direction = 1;


        public Game(string[] playerNames){
            main.shuffle();
            foreach (string name in playerNames)
            {
                players.Add(new Player(name));
            }

            foreach (Player p in players)
            {
                p.draw(main,7);
                p.Order();
            }
           
            table.draw(main);
            ShowTable();
            
        }

        public void Turn(Player player){
            player.Show();
            System.Console.WriteLine("Enter the card number you want to play:");
            int cardNumber = int.Parse(Console.ReadLine());
            player.GiveCard(cardNumber-1,table);
        }

        public void ShowTable(){
            Console.Clear();
            Console.WriteLine("---------------TABLE------------------");
            table.TopCard.Show();
            Console.WriteLine("--------------------------------------");
        }


    }
}
