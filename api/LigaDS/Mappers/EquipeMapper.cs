using LigaDS.Models;

namespace LigaDS.Mappers
{
    public static class EquipeMapper
    {
        public static Equipe ToEquipeModel(TeamFetchDTO teamDTO)
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
