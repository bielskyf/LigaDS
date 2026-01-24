using LigaDS.Models;
using LigaDS.Services.Interfaces;

namespace LigaDS.Services
{
    public class AtletaService : IAtletaService
    {
        private readonly IApiFootballService _apiFootballService;

        public AtletaService(IApiFootballService apiFootballService)
        {
            _apiFootballService = apiFootballService;
        }

        public async Task<List<Atleta>> GetAllNewPlayersAsync(int league, int season)
        {
            var playersDTO = await _apiFootballService.GetAllPlayersAsync(league, season);
            List<Atleta> atletas = [];

            foreach (var playerDTO in playersDTO)
            {
                atletas.Add(ConvertToAtletaModel(playerDTO));
            }
            
            return atletas;
        }

        public Atleta ConvertToAtletaModel(PlayerFetchDTO playerDTO)
        {
            var stats = playerDTO.Statistics.FirstOrDefault();
            string position = string.Empty;
            int overall = Convert.ToInt32(Convert.ToDouble(stats?.Games.Rating ?? 5) * 10);

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
    }
}
