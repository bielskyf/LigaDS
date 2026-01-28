using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IEquipeFetchService
    {
        public Task<List<Equipe>> GetAllNewTeamsAsync(int league, int season);
    }
}
