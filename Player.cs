namespace DeckOfCards
{
    public class Player : BaseCardSet
    {
        public string name;
        // hand = cards from Abstrace Base Class

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
        }
    }
}
