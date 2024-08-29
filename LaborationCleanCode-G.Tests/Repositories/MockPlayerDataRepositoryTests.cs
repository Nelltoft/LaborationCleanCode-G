using LaborationCleanCode_G.Core.Interfaces;
using LaborationCleanCode_G.Core.Models;

namespace LaborationCleanCode_G.Infrastructure.Repositories.Tests
{
    [TestClass()]
    public class MockPlayerDataRepositoryTests
    {
        IPlayerDataRepository _sut;

        [TestInitialize]
        public void Initialize() 
        {
            _sut = new MockPlayerDataRepository();

            var player = new PlayerData("Björn", 3);
            _sut.AddPlayer(player);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            // The code below empties the mockhighscore text file to save space.
            StreamWriter reset = new("mockhighscore.txt", false);
            reset.Write(string.Empty);
            reset.Close();           
        }

        [TestMethod()]
        public void GetAllPlayers_TestThatItReturnsAListOfPlayerData()
        {
            //assign

            //act
            var result = _sut.GetAllPlayers();

            //assert
            Assert.IsInstanceOfType<List<PlayerData>>(result);
        }
    }
}