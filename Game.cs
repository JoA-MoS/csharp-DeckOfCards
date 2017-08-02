using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Deck main = new Deck();
        public BaseCardSet table = new BaseCardSet();
        public int direction = 1;




        public Game(string[] playerNames)
        {
            main.shuffle();
            foreach (string name in playerNames)
            {
                players.Add(new Player(name));
            }

            foreach (Player p in players)
            {
                p.draw(main, 7);
                p.Order();
            }

            table.draw(main);


        }

        public void Turn(Player player)
        {
            ShowTable();
            player.Show();
            System.Console.WriteLine("Enter the card number you want to play:");
            int choice = int.Parse(Console.ReadLine());
            if (choice > 0)
            {
                player.GiveCard(choice - 1, table);
                if (!(table.TopCard.rank.value == table.cards[table.Count - 2].rank.value || table.TopCard.suit.name == table.cards[table.Count - 2].suit.name))
                {
                    player.draw(table);
                    player.Order();
                    Console.WriteLine("You cant play that card silly - Press enter to continue");
                    Console.ReadLine();

                    Turn(player);
                }
                if (table.TopCard.rank.name == "Skip") {
                    
                }
            }
            else
            {
                player.draw(main, 1);
                player.Order();
                Turn(player);
            }
        }



        public void ShowTable()
        {
            Console.Clear();
            Console.WriteLine("---------------TABLE------------------");
            table.TopCard.Show();
            Console.WriteLine($"table: {table.Count}\t main: {main.Count}");
            Console.WriteLine("--------------------------------------");
        }

        public void Play()
        {
            int turns = 0;
            while (!haveWinner())
            {
                System.Console.WriteLine(turns % players.Count);
                Turn(players[turns % players.Count]);
                turns++;
            }
            Player winner = players.Where(x => x.Count == 0).Single();
            System.Console.WriteLine($"!!!!!!!!!!!!!  {winner.name} WINS  !!!!!!!!!!!!!");
        }

        private bool haveWinner()
        {
            bool cont = false;
            foreach (Player player in players)
            {
                System.Console.WriteLine("Card Count " + player.cards.Count);
                cont = cont || player.cards.Count == 0;
                // System.Console.WriteLine(player.Count);
            }
            System.Console.WriteLine(cont);
            return cont;
        }
    }
}
