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
    }
}