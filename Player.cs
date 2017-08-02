namespace DeckOfCards
{
    public class Player : BaseCardSet
    {
        public string name;
        // hand = cards from Abstrace Base Class

        public Player()
        {

        }

        public Player(string name)
        {
            this.name = name;
        }


        public override string ToString()
        {
            return $"=================={name}=================\r\n"+base.ToString();
        }

        public void Show(){
            System.Console.WriteLine($"=================={name}=================\r\n");
            base.Show();
            System.Console.WriteLine($"-----------------------------------------\r\n");
            System.Console.WriteLine($"0: Draw a card\r\n");
        }
    }
}
