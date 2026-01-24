using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface IAtletaService
    {
        public Task<List<Atleta>> GetAllNewPlayersAsync(int league, int season);
    }
}
