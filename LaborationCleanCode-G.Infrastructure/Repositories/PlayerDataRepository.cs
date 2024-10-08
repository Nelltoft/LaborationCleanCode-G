﻿using LaborationCleanCode_G.Core.Models;
using LaborationCleanCode_G.Core.Interfaces;

namespace LaborationCleanCode_G.Infrastructure.Repositories;

public class PlayerDataRepository : IPlayerDataRepository
{

    public void AddPlayer(IPlayerData playerData)
    {
        StreamWriter request = new("highscore.txt", append: true);
        request.WriteLine($"{playerData.Name}#&#{playerData.TotalGuesses}");
        request.Close();
    }

    public ICollection<PlayerData> GetAllPlayers()
    {
        StreamReader response = new("highscore.txt");
        List<PlayerData> playerList = new();
        string line;
        int playerListStartingIndex = 0;

        while ((line = response.ReadLine()!) is not null)
        {
            string[] playerNameAndGuesses = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = playerNameAndGuesses[0];
            int guesses = Convert.ToInt32(playerNameAndGuesses[1]);
            PlayerData player = new(name, guesses);
            int index = playerList.IndexOf(player);
            if (index < playerListStartingIndex)
            {
                playerList.Add(player);
            }
            else
            {
                playerList[index].Update(guesses);
            }
        }
        response.Close();

        return playerList.OrderBy(p => p.Average()).ToList();
    }
}
