using LaborationCleanCode_G.Core.Interfaces;
using LaborationCleanCode_G.Core.Models;
using System.Text;

namespace LaborationCleanCode_G.Core.Services;

public class MooGameService : IGameService
{
    private readonly IInputOutput _iO;
    private readonly IPlayerDataRepository _playerDataRepository;

    public MooGameService(IInputOutput iO, IPlayerDataRepository playerDataRepository)
    {
        _iO = iO;
        _playerDataRepository = playerDataRepository;
    }

    public void StartGame(string name)
    {
        string goal = GenerateGoal();

        
        string playerName = name;
        int numberOfGuesses = 1;

        _iO.Output("New Game:\n");
        //comment out or remove next line to play real games!
        _iO.Output($"For practice, the number is {goal}\n");

        string playerInput = _iO.Input();

        string checkedWinCondition = CheckWinCondition(goal, playerInput);

        _iO.Output($"{checkedWinCondition}\n");

        while (checkedWinCondition != "BBBB,")
        {
            numberOfGuesses++;
            playerInput = _iO.Input();
            checkedWinCondition = CheckWinCondition(goal, playerInput);
            _iO.Output($"{checkedWinCondition}\n");
        }

        IPlayerData player = new PlayerData(playerName, numberOfGuesses);
        _playerDataRepository.AddPlayer(player);
        ShowHighScore();


        if (numberOfGuesses > 1)
        {
            _iO.Output($"Correct, it took {numberOfGuesses} guesses\n");
        }
        else
        {
            _iO.Output($"Correct, it took {numberOfGuesses} guess\n");
        }
    }

    public string GenerateGoal()
    {
        Random randomGenerator = new();
        var availableNumbers = Enumerable.Range(0, 10).ToList();

        string goal = "";

        for (int i = 0; i < 4; i++)
        {
            var index = randomGenerator.Next(availableNumbers.Count);
            goal += availableNumbers[index].ToString();
            availableNumbers.RemoveAt(index);
        }

        return goal;
    }

    /// <summary>
    /// Compares the players guess to the goal of the game
    /// </summary>
    /// <param name="goal"></param>
    /// <param name="guess"></param>
    /// <returns>String of BBBB, if the players guess is the same as the goal of the game</returns>
    public string CheckWinCondition(string goal, string guess)
    {
        StringBuilder bullsAndCows = new();

        if (guess.Length != goal.Length)
        {
            return "Please type 4 unique numbers between 0 and 9.";
        }

        if (guess == goal)
        {
            return bullsAndCows.Append("BBBB,").ToString();
        }

        bullsAndCows.Append(',');

        for (int i = 0; i < 4; i++)
        {
            if (guess[i].Equals(goal[i]))
            {
                bullsAndCows.Insert(0, "B");
            }
            else if (goal.Contains(guess[i]))
            {
                bullsAndCows.Append('C');
            }
        }
        return bullsAndCows.ToString();
    }

    void ShowHighScore()
    {
        var highScoreList  = _playerDataRepository.GetAllPlayers();

        _iO.Output($"{"Player",-9}{"Games",-9}{"Average",-9}");
        _iO.Output("------------------------");

        foreach (var player in highScoreList)
        {
            _iO.Output($"{player.Name,-9}{player.NumberOfGames,-9}{player.Average(),-9}\n");
        }
    }
}
