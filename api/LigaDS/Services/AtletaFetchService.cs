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
                atletas.Add(ConvertToAtletaModel(playerDTO, league));
            }
            
            return atletas;
        }

        public Atleta ConvertToAtletaModel(PlayerFetchDTO playerDTO, int league)
        {
            var stats = playerDTO.Statistics.FirstOrDefault();
            string position = string.Empty;
            int overall = Convert.ToInt32(Convert.ToDouble(stats?.Games.Rating ?? 5) * OverallLeagueMapper(league));

            switch (stats?.Games.Position)
            {
                case "Goalkeeper":
                    position = "Goleiro";
                    break;
                case "Defender":
                    position = "Defensor";
                    break;
                case "Midfielder":
                    position = "Meio-campista";
                    break;
                case "Attacker":
                    position = "Atacante";
                    break;
                default:
                    position = "Desconhecido";
                    break;
            }

            return new Atleta
            {
                Id = playerDTO.Player.Id,
                Nome = playerDTO.Player.Name,
                Idade = playerDTO.Player.Age,
                Nacionalidade = playerDTO.Player.Nationality,
                FotoUrl = playerDTO.Player.Photo,
                Posicao = position,
                Overall = overall,
                EquipeId = stats?.Team.Id ?? 0,
                LigaId = stats?.League.Id ?? 0
            };
        }

        private double OverallLeagueMapper(int league)
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
