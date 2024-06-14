using LaborationCleanCode_G.Core.Interfaces;
using LaborationCleanCode_G.Core.Models;

namespace LaborationCleanCode_G.Controllers;

public class MooGameController : IGameController
{
    private readonly IGameService _gameService;
    private readonly IInputOutput _iO;

    public MooGameController(IGameService gameService, IInputOutput iO)
    {
        _gameService = gameService;
        _iO = iO;
    }

    public void RunGame()
    {
        string answer;

        _iO.Output("Enter your user name:\n");
        string playerName = _iO.Input();

        do
        {
            _iO.Clear();
            _gameService.StartGame(playerName);
            _iO.Output($"Type [y] to start new game.");
            answer = _iO.Input().ToLower();
        } while (answer == "y");
        
    }
}
