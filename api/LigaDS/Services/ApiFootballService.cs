using LigaDS.Models;
using LigaDS.Services.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json;

namespace LigaDS.Services
{
    public class ApiFootballService : IApiFootballService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly ILogger _logger;
        private readonly string _apiKey;

        public ApiFootballService(HttpClient httpClient, ILogger<ApiFootballService> logger)
        {
            _httpClient = httpClient;

            // Lido do arquivo .env.local
            _apiKey = Environment.GetEnvironmentVariable("API_EXTERNA_KEY");

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("Configurações da API externa não encontradas. Configure o arquivo .env.local");
            }

            _httpClient.BaseAddress = new Uri("https://v3.football.api-sports.io/");

            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _apiKey);

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _logger = logger;
        }

        private async Task<List<PlayerFetchDTO>> GetPlayersAsync(int league, int season, int page, List<PlayerFetchDTO> playersDTO)
        {
            var response = await _httpClient.GetAsync($"players?league={league}&season={season}&page={page}");
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiPlayersResponse>(_jsonOptions);

            if (apiResponse?.Response != null)
            {
                _logger.LogInformation(
                    "Página {Current}/{Total} processada. Total acumulado: {Count} jogadores",
                    apiResponse.Paging.Current,
                    apiResponse.Paging.Total,
                    playersDTO.Count
                );

                playersDTO.AddRange(apiResponse.Response);
            }

            if (apiResponse?.Paging != null && apiResponse.Paging.Current < apiResponse.Paging.Total)
            {
                var nextPage = apiResponse.Paging.Current++;

                await Task.Delay(1000);

                playersDTO = await GetPlayersAsync(league, season, nextPage, playersDTO);
            }

            return playersDTO;
        }

        public async Task<List<PlayerFetchDTO>> GetAllPlayersAsync(int league, int season)
        {
            var playersDTO = new List<PlayerFetchDTO>();

            try
            {
                playersDTO = await GetPlayersAsync(league, season, 1, playersDTO);
                _logger.LogInformation("Total de {Count} jogadores obtidos.", playersDTO.Count);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Erro ao obter jogadores: {Message}", ex.Message);
                return null;
            }

            return playersDTO;
        }

        public async Task<List<TeamFetchDTO>> GetAllTeamsAsync(int league, int season)
        {
            var teamsDTO = new List<TeamFetchDTO>();

            try
            {
                var response = await _httpClient.GetAsync($"teams?league={league}&season={season}");

                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiTeamsResponse>(_jsonOptions);

                if (apiResponse?.Response != null)
                {
                    teamsDTO.AddRange(apiResponse.Response);
                }

                _logger.LogInformation("Total de {Count} equipes obtidas.", teamsDTO.Count);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Erro ao obter equipes: {Message}", ex.Message);
                return null;
            }

            return teamsDTO;
        }
    }
}
