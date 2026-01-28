using LigaDS.Models;

namespace LigaDS.Services.Interfaces
{
    public interface ILigaFetchService
    {
        public Task<Liga> GetNewLigaAsync(int league, int season);
    }
}
