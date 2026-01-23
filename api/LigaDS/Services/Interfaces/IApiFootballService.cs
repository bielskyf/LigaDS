using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IApiFootballService
    {
        public Task<List<PlayerData>> GetAllPlayersAsync(int league, int season);
        public Task<List<TeamData>> GetAllTeamsAsync(int league, int season);
    }
}
