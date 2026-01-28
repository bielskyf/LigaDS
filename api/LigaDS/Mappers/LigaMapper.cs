using LigaDS.Models;

namespace LigaDS.Mappers
{
    public static class LigaMapper
    {
        public static Liga ToLigaModel(LeagueFetchDTO leagueDTO)
        {
            return new Liga
            {
                Id = leagueDTO.League.Id,
                Nome = leagueDTO.League.Name
            };
        }
    }
}
