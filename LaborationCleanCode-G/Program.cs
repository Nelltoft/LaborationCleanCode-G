using LaborationCleanCode_G.Controllers;
using LaborationCleanCode_G.Core.Interfaces;
using LaborationCleanCode_G.Core.Services;
using LaborationCleanCode_G.Infrastructure.Repositories;

namespace LaborationCleanCode_G;

class Program
{
    static void Main()
    {
        IInputOutput _iO = new ConsoleIO();
        IPlayerDataRepository _playerDataRepository = new PlayerDataRepository(_iO);
        IGameService _gameService = new MooGameService(_iO, _playerDataRepository);
        IGameController _gameController = new MooGameController(_gameService, _iO);
        _gameController.RunGame();
    }
}
