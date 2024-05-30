using GoFishGame;
using System.Numerics;

namespace GoFishTest
{
    [TestClass]
    public class GameTests
    {
        //test method to initialize game
        [TestMethod]
        public void TestGameInitialization()
        {
            Player player = new Player("Player");
            Player computer = new Player("Computer");
            Deck deck = new Deck();

            Game game = new Game(player, computer, deck);

            Assert.IsNotNull(game);
            Assert.AreEqual(player, game.Player);
            Assert.AreEqual(computer, game.Computer);
            Assert.AreEqual(deck, game.Deck);
        }

        //test method to display Instructions
        [TestMethod]
        public void TestDisplayInstructions()
        {
            var player = new Player("Player1");
            var computer = new Player("Computer");
            var deck = new Deck();
            var game = new Game(player, computer, deck);

            game.DisplayInstructions();
        }

        //test method to deal inititial card
        [TestMethod]
        public void TestDealInitialCards()
        {
            var player = new Player("Player1");
            var computer = new Player("Computer");
            var deck = new Deck();
            deck.Shuffle();
            var game = new Game(player, computer, deck);

            game.DealInitialCards();

            Assert.AreEqual(7, player.Hand.Count);
            Assert.AreEqual(7, computer.Hand.Count);
        }

        //test method to verify that card is drawn from deck
        [TestMethod]
        public void TestDrawCard()
        {
            var deck = new Deck();

            var card = deck.Draw();

            Assert.IsNotNull(card);
            Assert.AreEqual(51, deck.Cards.Count);
        }

        //test method to determine winner of the game
        [TestMethod]
        public void TestDetermineWinner_PlayerWins()
        {
            var player = new Player("Player1");
            var computer = new Player("Computer");
            var deck = new Deck();
            var game = new Game(player, computer, deck);

            player.Hand.AddRange(new List<Card> {
                new Card("7", "Hearts"),
                new Card("7", "Diamonds"),
                new Card("7", "Clubs"),
                new Card("7", "Spades")
            });
            player.TakeCards(computer, "7"); // Player completes a set

            var winner = game.DetermineWinner();

            Assert.AreEqual(player, winner);
        }

        //
        [TestMethod]
        public void TestShuffle()
        {
            Deck deck = new Deck();
            List<Card> originalOrder = new List<Card>(deck.Cards);

            deck.Shuffle();
            List<Card> shuffledOrder = deck.Cards;

            // Check the number of cards is the same
            Assert.AreEqual(originalOrder.Count, shuffledOrder.Count, "The number of cards should remain the same after shuffling.");

            // Check all cards are still present
            foreach (Card card in originalOrder)
            {
                Assert.IsTrue(shuffledOrder.Contains(card), $"The card {card} should be present after shuffling.");
            }

            // Check that the order has changed
            bool orderChanged = false;
            for (int i = 0; i < originalOrder.Count; i++)
            {
                if (originalOrder[i] != shuffledOrder[i])
                {
                    orderChanged = true;
                    break;
                }
            }
            Assert.IsTrue(orderChanged, "The order of cards should change after shuffling.");
        }

        //for failing
        // Test that initializing the game with a null player throws an exception
        [TestMethod]
        public void TestGameInitialization_NullPlayer()
        {
            Player player = null;
            Player computer = new Player("Computer");
            Deck deck = new Deck();

            try
            {
                new Game(player, computer, deck);
                Assert.Fail("Expected ArgumentNullException for null player, but no exception was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("player", ex.ParamName, "Unexpected parameter name in ArgumentNullException.");
            }
        }
    }
}