using LaborationCleanCode_G.Core.Models;
using LaborationCleanCode_G.Core.Interfaces;

namespace LaborationCleanCode_G.Infrastructure.Repositories;

public class PlayerDataRepository : IPlayerDataRepository
{
    private readonly IInputOutput _iO;

    public PlayerDataRepository(IInputOutput iO)
    {
        _iO = iO;
    }

    public void AddPlayer(IPlayerData playerData)
    {
        StreamWriter output = new("highscore.txt", append: true);
        output.WriteLine($"{playerData.Name}#&#{playerData.TotalGuesses}");
        output.Close();
    }

    public void GetAllPlayers()
    {
        StreamReader response = new("highscore.txt");
        List<PlayerData> playerList = new();
        string line;

        while ((line = response.ReadLine()!) is not null)
        {
            string[] playerNameAndGuesses = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = playerNameAndGuesses[0];
            int guesses = Convert.ToInt32(playerNameAndGuesses[1]);
            PlayerData player = new(name, guesses);
            int index = playerList.IndexOf(player);
            if (index < 0)
            {
                playerList.Add(player);
            }
            else
            {
                playerList[index].Update(guesses);
            }
        }

        _iO.Output($"{"Player",-9}{"Games",5:D}{"Average",9:F2}");
        _iO.Output("------------------------");

        foreach (var player in playerList.OrderBy(p => p.Average()))
        {
            _iO.Output($"{player.Name,-9}{player.NumberOfGames,5:D}{player.Average(),9:F2}\n");
        }
        response.Close();
    }
}
