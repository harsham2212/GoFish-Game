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
    }
}