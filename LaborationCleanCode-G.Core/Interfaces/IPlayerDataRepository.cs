using LaborationCleanCode_G.Core.Models;

namespace LaborationCleanCode_G.Core.Interfaces;

public interface IPlayerDataRepository
{
    void AddPlayer(IPlayerData playerData);
    ICollection<PlayerData> GetAllPlayers();
}
