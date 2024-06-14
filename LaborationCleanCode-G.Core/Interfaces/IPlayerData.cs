using LaborationCleanCode_G.Core.Models;

namespace LaborationCleanCode_G.Core.Interfaces;

public interface IPlayerData
{
    public string Name { get;}
    public int NumberOfGames { get;}
    public int TotalGuesses { get; set; }

    public void Update(int guesses);
    public double Average();
}
