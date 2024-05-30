using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishGame
{
    public class Game
    {
        public Player Player { get; }
        public Player Computer { get; }
        public Deck Deck { get; }

        public Game(Player player, Player computer, Deck deck)
        {
            Player = player;
            Computer = computer;
            Deck = deck;
        }

        public void Start()
        {
            DisplayInstructions();
            DealInitialCards();

            while (Player.Hand.Count > 0 && Computer.Hand.Count > 0)
            {
                PlayerTurn(Player, Computer);
                if (Player.Hand.Count == 0)
                {
                    Console.WriteLine($"{Player.Name} has no cards left!");
                    break;
                }
                PlayerTurn(Computer, Player);
                if (Computer.Hand.Count == 0)
                {
                    Console.WriteLine($"{Computer.Name} has no cards left!");
                    break;
                }
            }
            DetermineWinner();
        }

        public void DisplayInstructions()
        {
            Console.WriteLine("\nGame Instructions:");
            Console.WriteLine("1. You will be dealt 7 cards to start with.");
            Console.WriteLine("2. On your turn, ask the computer for a rank (e.g., 'Do you have any 7s?').");
            Console.WriteLine("3. If the computer has cards of the rank you asked for, they will give them to you.");
            Console.WriteLine("4. If the computer doesn't have the cards, you will draw a card from the deck.");
            Console.WriteLine("5. Try to collect all 4 cards of the same rank to complete a set.");
            Console.WriteLine("6. The game continues until one player runs out of cards.");
            Console.WriteLine("7. The player with the most sets at the end of the game wins.\n");
            Console.WriteLine("Let's start the game!\n");
        }

        public void DealInitialCards()
        {
            for (int i = 0; i < 7; i++)
            {
                Player.DrawCard(Deck);
                Computer.DrawCard(Deck);
            }

            Console.WriteLine("Initial hands dealt.\n");
        }

        public void PlayerTurn(Player currentPlayer, Player opponent, string rank = null)
        {
            if (currentPlayer.Hand.Count == 0)
            {
                Console.WriteLine($"{currentPlayer.Name} has no cards left.");
                return;
            }

            Console.WriteLine($"{currentPlayer.Name}'s turn:");
            Console.WriteLine($"{currentPlayer.Name}'s hand: {currentPlayer.ShowHand()}");
            Console.WriteLine();

            if (rank == null)
            {
                if (currentPlayer.Name == "Computer")
                {
                    rank = currentPlayer.Hand[new Random().Next(currentPlayer.Hand.Count)].Rank;
                    Console.WriteLine($"{currentPlayer.Name} asks: Do you have any {rank}s?");
                }
                else
                {
                    Console.Write("Ask for a rank (e.g., 7, J, Q): ");
                    rank = Console.ReadLine();

                    while (!IsValidRank(rank))
                    {
                        Console.WriteLine("Invalid rank. Please try again.");
                        rank = Console.ReadLine();
                    }
                }
            }

            if (opponent.HasRank(rank))
            {
                Console.WriteLine($"{opponent.Name} has {rank}s.");
                currentPlayer.TakeCards(opponent, rank); // Player takes cards from opponent
                Console.WriteLine($"{currentPlayer.Name} takes all {rank}s from {opponent.Name}.\n");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} says: Go Fish!");
                currentPlayer.DrawCard(Deck); // Player draws a card from the deck
                Console.WriteLine($"{currentPlayer.Name} draws a card from the deck.\n");
            }
        }

        private bool IsValidRank(string rank)
        {
            string[] validRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            return validRanks.Contains(rank);
        }

        public Player DetermineWinner()
        {
            int playerSets = Player.Sets;
            int computerSets = Computer.Sets;

            if (playerSets > computerSets)
            {
                Console.WriteLine($"{Player.Name} wins with {playerSets} sets!");
                return Player;
            }
            else if (computerSets > playerSets)
            {
                Console.WriteLine($"{Computer.Name} wins with {computerSets} sets!");
                return Computer;
            }
            else
            {
                Console.WriteLine("It's a tie!");
                return null; // Return null in case of a tie
            }
        }
    }
}
