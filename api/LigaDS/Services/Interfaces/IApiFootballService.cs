using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IApiFootballService
    {
        public Task<List<PlayerFetchDTO>> GetAllPlayersAsync(int league, int season);
        public Task<List<TeamFetchDTO>> GetAllTeamsAsync(int league, int season);
    }
}
