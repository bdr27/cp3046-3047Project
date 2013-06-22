
using System.Collections.Generic;
namespace LeaderBoardApp.Utility
{
    public interface FileHandler
    {
        void LoadPlayers();
        Dictionary<int, Player> GetPlayers();
        void InsertPlayer(Player newPlayer);
        void UpdatePlayer(Player editPlayer);
        void DeletePlayer(Player deletePlayer);
    }
}
