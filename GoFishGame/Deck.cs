using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishGame
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        public List<Card> Cards => cards;

        public Deck()
        {
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("No cards left in the deck!");
                return null;
            }

            Card card = cards.Last();
            cards.Remove(card);
            return card;
        }
    }
}
