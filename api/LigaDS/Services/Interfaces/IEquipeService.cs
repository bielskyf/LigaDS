using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IEquipeService
    {
        public Task<List<Equipe>> GetAllNewTeamsAsync(int league, int season);
    }
}
