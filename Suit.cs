using System;

namespace DeckOfCards
{
    public class Suit
    {
        public string name;
        public ConsoleColor textColor;
        public ConsoleColor backgroundColor;

        public Suit(string name, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            this.name = name;
            this.textColor = textColor;
            this.backgroundColor = backgroundColor;
        }

    }
}
