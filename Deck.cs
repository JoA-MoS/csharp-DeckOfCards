using System;
using System.Collections.Generic;
using System.Linq;
namespace DeckOfCards
{
    public class Deck : BaseCardSet
    {
        public static Suit[] standardSuits = { new Suit("Blue", ConsoleColor.Black, ConsoleColor.DarkBlue),
                                                new Suit("Green", ConsoleColor.Black, ConsoleColor.DarkGreen),
                                                new Suit("Red", ConsoleColor.Black, ConsoleColor.DarkRed),
                                                new Suit("Yellow", ConsoleColor.Black, ConsoleColor.DarkYellow),
                                             };
        protected static Rank[] standardRanks = { new Rank("0", 0),
                                                    new Rank("1", 1),
                                                    new Rank( "2", 2),
                                                    new Rank( "3", 3),
                                                    new Rank( "4", 4),
                                                    new Rank( "5", 5),
                                                    new Rank( "6", 6),
                                                    new Rank( "7", 7),
                                                    new Rank( "8", 8),
                                                    new Rank( "9", 9),
                                                    new Rank( "Skip", 10),
                                                    new Rank( "Reverse", 11),
                                                    new Rank( "Draw 2", 12)};

        protected Rank[] noZero = { new Rank("1", 1),
                                    new Rank( "2", 2),
                                    new Rank( "3", 3),
                                    new Rank( "4", 4),
                                    new Rank( "5", 5),
                                    new Rank( "6", 6),
                                    new Rank( "7", 7),
                                    new Rank( "8", 8),
                                    new Rank( "9", 9),
                                    new Rank( "Skip", 10),
                                    new Rank( "Reverse", 11),
                                    new Rank( "Draw 2", 12)};

        protected Suit[] wildSuits = { new Suit("", ConsoleColor.White, ConsoleColor.Black), };
        protected static Rank[] wildRanks = { new Rank("Wild", 100),
                                               new Rank("Wild", 100),
                                               new Rank("Wild", 100),
                                               new Rank("Wild", 100),
                                               new Rank("Wild Draw 4",200),
                                               new Rank("Wild Draw 4",200),
                                               new Rank("Wild Draw 4", 200),
                                               new Rank("Wild Draw 4",200),
                                              };

        public static List<CardGroup> cardGroups = new List<CardGroup>();






        public Deck()
        {
            cardGroups.Add(new CardGroup(standardSuits.ToList(), standardRanks.ToList()));
            cardGroups.Add(new CardGroup(standardSuits.ToList(), noZero.ToList()));
            cardGroups.Add(new CardGroup(wildSuits.ToList(), wildRanks.ToList()));
            createDeck();
        }

        // private void createDeck()
        // {
        //     for (int s = 0; s < suits.Length; s++)
        //     {
        //         for (int r = 0; r < ranks.Length; r++)
        //         {
        //             cards.Add(new Card(s, r));
        //         }
        //     }

        // }

        private void createDeck()
        {
            foreach (CardGroup cardGroup in cardGroups)
            {
                foreach (Suit suit in cardGroup.suits)
                {
                    foreach (Rank rank in cardGroup.ranks)
                    {
                        cards.Add(new Card(suit, rank));
                    }
                }
            }

        }

        private void resetDeck()
        {
            cards.Clear();
            createDeck();
        }
    }


}
