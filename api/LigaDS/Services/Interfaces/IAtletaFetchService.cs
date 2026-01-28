using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IAtletaFetchService
    {
        public Task<List<Atleta>> GetAllNewPlayersAsync(int league, int season);
    }
}
