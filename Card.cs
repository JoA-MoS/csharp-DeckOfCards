using System;

namespace DeckOfCards
{

    public class Card
    {

        public string strValue;
        public Suit suit;
        public Rank rank;

        public Card(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;

        }

        public override string ToString()
        {
            return $"{suit.name} {rank.name}";
        }

        public void Show(){
            Console.BackgroundColor = suit.backgroundColor;
            Console.ForegroundColor = suit.textColor;
            Console.WriteLine(this);
            Console.ResetColor();
        }

        public void Show(int count){
            Console.BackgroundColor = suit.backgroundColor;
            Console.ForegroundColor = suit.textColor;
            Console.WriteLine(count +": " + this);
            Console.ResetColor();
        }
    }
}
