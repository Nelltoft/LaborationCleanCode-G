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
        }

        [TestMethod()]
        public void GetAllPlayers_TestThatItReturnsAListOfPlayerData()
        {
            //assign
            var player = new PlayerData("Björn", 3);
            _sut.AddPlayer(player);

            //act
            var result = _sut.GetAllPlayers();

            //assert
            Assert.IsInstanceOfType<List<PlayerData>>(result);
        }
    }
}