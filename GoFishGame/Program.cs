using System.Numerics;

namespace GoFishGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Go Fish!");
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);
            Player computer = new Player("Computer");
            Deck deck = new Deck();
            deck.Shuffle();

            Game game = new Game(player, computer, deck);
            game.Start();
        }
    }
}