using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishGame
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }
        public int Sets { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void DrawCard(Deck deck)
        {
            Card card = deck.Draw();
            if (card != null)
            {
                Hand.Add(card);
            }
        }

        public void TakeCards(Player opponent, string rank)
        {
            List<Card> cardsToTake = opponent.Hand.Where(card => card.Rank == rank).ToList();
            Hand.AddRange(cardsToTake);
            opponent.Hand.RemoveAll(card => card.Rank == rank);

            if (Hand.Count(card => card.Rank == rank) == 4)
            {
                Sets++;
                Hand.RemoveAll(card => card.Rank == rank);
                Console.WriteLine($"{Name} completed a set of {rank}s!");
            }
        }

        public bool HasRank(string rank)
        {
            return Hand.Exists(card => card.Rank == rank);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Player other = (Player)obj;
            return Name == other.Name;
        }

        public string ShowHand()
        {
            return string.Join(", ", Hand.Select(card => card.ToString()));
        }
    }
}