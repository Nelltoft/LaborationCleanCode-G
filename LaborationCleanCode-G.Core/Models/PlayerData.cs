using LaborationCleanCode_G.Core.Interfaces;

namespace LaborationCleanCode_G.Core.Models;

public class PlayerData : IPlayerData
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    public int TotalGuesses { get; set; }

    public PlayerData(string name, int guesses)
    {
        Name = name;
        NumberOfGames = 1;
        TotalGuesses = guesses;
    }

    public void Update(int guesses)
    {
        TotalGuesses += guesses;
        NumberOfGames++;
    }

    public double Average()
    {
        return (double)TotalGuesses / NumberOfGames;
    }

    public override bool Equals(Object player)
    {
        return Name.Equals(((PlayerData)player).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
