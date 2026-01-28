using LigaDS.Mappers;
using LigaDS.Models;
using LigaDS.Services.Interfaces;

namespace LigaDS.Services
{
    public class LigaFetchService : ILigaFetchService
    {
        private readonly IApiFootballService _apiFootballService;

        public LigaFetchService(IApiFootballService apiFootballService)
        {
            _apiFootballService = apiFootballService;
        }

        public async Task<Liga> GetNewLigaAsync(int league, int season)
        {
            var ligaDTO = await _apiFootballService.GetLeagueAsync(league, season);
            var liga = LigaMapper.ToLigaModel(ligaDTO);
            return liga;
        }
    }
}
