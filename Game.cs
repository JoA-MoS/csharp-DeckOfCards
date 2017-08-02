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

        private int turns = 1;




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
                if (table.TopCard.rank.value >= 100)
                {
                    // 200 is the value of draw 4
                    if(table.TopCard.rank.value==200){
                        Player nextPlayer = players[Math.Abs((turns + direction) % players.Count)];
                        nextPlayer.draw(main, 4);
                        System.Console.WriteLine($"----------{nextPlayer.name} Drawing 4 cards ------");
                        System.Threading.Thread.Sleep(3000);
                        nextPlayer.Order();
                    }
                    System.Console.WriteLine("1: Blue");
                    System.Console.WriteLine("2: Green");
                    System.Console.WriteLine("3: Red");
                    System.Console.WriteLine("4: Yellow");
                    System.Console.WriteLine("What color do you want?");
                    int colorChoice = int.Parse(Console.ReadLine());

                    table.TopCard.suit = Deck.standardSuits[colorChoice-1];


                    
                }
                else
                {
                    if (!(table.TopCard.rank.value == table.cards[table.Count - 2].rank.value ||
                            table.TopCard.suit.name == table.cards[table.Count - 2].suit.name))
                    {
                        player.draw(table);
                        player.Order();
                        Console.WriteLine("You cant play that card silly - Press enter to continue");
                        Console.ReadLine();

                        Turn(player);
                    }
                    SpecialCards();
                }

            }
            else
            {
                player.draw(main, 1);
                player.Order();
                Turn(player);
            }
        }

        private void SpecialCards(bool useNext=true)
        {
            if (table.TopCard.rank.name == "Skip")
            {
                System.Console.WriteLine($"---------- Next Player Skipped ------");
                System.Threading.Thread.Sleep(3000);
                turns += direction;
            }
            if (table.TopCard.rank.name == "Reverse")
            {
                System.Console.WriteLine($"---------- Game Direction Reversed ------");
                System.Threading.Thread.Sleep(3000);
                direction = -1;
            }
            if (table.TopCard.rank.name == "Draw 2")
            {
                Player nextPlayer = new Player();
                if(useNext){
                    nextPlayer = players[Math.Abs((turns + direction) % players.Count)];
                }else{
                    nextPlayer = players[Math.Abs((turns) % players.Count)];
                }

                nextPlayer.draw(main, 2);
                System.Console.WriteLine($"----------{nextPlayer.name} Drawing 2 cards ------");
                System.Threading.Thread.Sleep(3000);
                nextPlayer.Order();
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
            table.draw(main);
            while(table.TopCard.rank.value >= 100)
            {
                main.draw(table);
                main.shuffle();
                table.draw(main);
            }
            SpecialCards();

            while (!haveWinner())
            {
                Turn(players[Math.Abs(turns % players.Count)]);
                turns += direction;
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
