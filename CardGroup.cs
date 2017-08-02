using System.Collections.Generic;


namespace DeckOfCards
{
    public class CardGroup
    {
        public List<Suit> suits = new List<Suit>();
        public List<Rank> ranks= new List<Rank>();

        public CardGroup(){}

        public CardGroup(List<Suit> suits, List<Rank> ranks){
            this.suits = suits;
            this.ranks = ranks;
        }
    }
}
