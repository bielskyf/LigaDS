using LigaDS.Mappers;
using LigaDS.Models;
using LigaDS.Repository.Interfaces;
using LigaDS.Services.Interfaces;

namespace LigaDS.Services
{
    public class EquipeFetchService : IEquipeFetchService
    {
        private readonly IApiFootballService _apiFootballService;

        public EquipeFetchService(IApiFootballService apiFootballService)
        {
            _apiFootballService = apiFootballService;
        }

        public async Task<List<Equipe>> GetAllNewTeamsAsync(int league, int season)
        {
            var teamsDTO = await _apiFootballService.GetAllTeamsAsync(league, season);
            List<Equipe> equipes = [];

            foreach (var teamDTO in teamsDTO)
            {
                var equipe = EquipeMapper.ToEquipeModel(teamDTO);
                equipes.Add(equipe);
            }

            return equipes;
        }
    }
}
