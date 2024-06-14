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
        StreamWriter output = new StreamWriter("highscore.txt", append: true);
        output.WriteLine($"{playerData.Name}#&#{playerData.TotalGuesses}");
        output.Close();
    }

    public void GetAllPlayers()
    {
        StreamReader response = new StreamReader("highscore.txt");
        List<PlayerData> playerList = new();

        string line;
        while ((line = response.ReadLine()!) != null)
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

        playerList.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));

        _iO.Output($"{"Player",-9}{"Games",5:D}{"Average",9:F2}");
        _iO.Output("------------------------");
        foreach (var player in playerList)
        {
            _iO.Output($"{player.Name,-9}{player.NumberOfGames,5:D}{player.Average(),9:F2}\n");
        }
        response.Close();

        /*var playerList = response.ReadLine()
        .Select(line => line.Split(new[] { "#&#" }, StringSplitOptions.None))
        .Select(data => new PlayerData(data[0], Convert.ToInt32(data[1])))
        .GroupBy(player => player.Name)
        .Select(group =>
        {
            var playerData = group.First();
            playerData.Update(group.Sum(p => p.Guesses));
            return playerData;
        })
        .OrderBy(player => player.Average())
        .ToList();*/
    }
}
