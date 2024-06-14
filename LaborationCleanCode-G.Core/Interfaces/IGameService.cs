namespace LaborationCleanCode_G.Core.Interfaces;

public interface IGameService
{
    void StartGame(string name);
    string GenerateGoal();
    string CheckWinCondition(string goal, string guess);
}
