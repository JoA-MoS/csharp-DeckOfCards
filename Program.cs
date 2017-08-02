using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("How Many Players?");
            int players = int.Parse(Console.ReadLine());
            List<string> playerNames = new List<string>();
            for (int i = 0; i < players; i++)
            {
                System.Console.WriteLine($"Enter Player {i+1}'s name:");
                playerNames.Add(Console.ReadLine());
            }
            


            Game uno = new Game(playerNames.ToArray());
    
            // uno.Turn(uno.players[0]);
            uno.Play();
            



        }


    }
}
