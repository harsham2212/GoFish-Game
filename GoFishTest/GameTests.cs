using GoFishGame;
using System.Numerics;

namespace GoFishTest
{
    [TestClass]
    public class GameTests
    {
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
    }
}