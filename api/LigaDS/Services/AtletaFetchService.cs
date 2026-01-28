using LigaDS.Mappers;
using LigaDS.Models;
using LigaDS.Services.Interfaces;

namespace LigaDS.Services
{
    public class AtletaFetchService : IAtletaFetchService
    {
        private readonly IApiFootballService _apiFootballService;

        public AtletaFetchService(IApiFootballService apiFootballService)
        {
            _apiFootballService = apiFootballService;
        }

        public async Task<List<Atleta>> GetAllNewPlayersAsync(int league, int season)
        {
            var playersDTO = await _apiFootballService.GetAllPlayersAsync(league, season);
            List<Atleta> atletas = [];

            foreach (var playerDTO in playersDTO)
            {
                var stats = playerDTO.Statistics.FirstOrDefault();
                int overall = Convert.ToInt32(Convert.ToDouble(stats?.Games.Rating ?? 5) * OverallLeagueMapper(league));
                var atleta = AtletaMapper.ToAtletaModel(playerDTO);
                atleta.Overall = overall;
                atleta.Posicao = PositionMapper(stats?.Games.Position ?? string.Empty);
            }
            
            return atletas;
        }

        private static string PositionMapper(string position)
        {
            switch (position)
            {
                case "Goalkeeper":
                    return "Goleiro";
                case "Defender":
                    return "Defensor";
                case "Midfielder":
                    return "Meio-campista";
                case "Attacker":
                    return "Atacante";
                default:
                    return "Desconhecido";
            }
        }

        private static double OverallLeagueMapper(int league)
        {
            switch (league)
            {
                case 39: // Premier League
                    return 9.6;
                case 140: // La Liga
                    return 9.1;
                case 78: // Bundesliga
                    return 8.6;
                case 135: // Serie A
                    return 8.8;
                case 61: // Ligue 1
                    return 8.3;
                case 71: // Brasileirão Série A
                    return 7.9;
                default:
                    return 7.5;
            }
        }
    }
}
