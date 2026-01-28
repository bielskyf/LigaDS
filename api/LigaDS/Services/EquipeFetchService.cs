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
                equipes.Add(ConvertToEquipeModel(teamDTO));
            }

            return equipes;
        }

        public Equipe ConvertToEquipeModel(TeamFetchDTO teamDTO)
        {
            return new Equipe
            {
                Id = teamDTO.Team.Id,
                Nome = teamDTO.Team.Name,
                LogoUrl = teamDTO.Team.Logo
            };
        }
    }
}
