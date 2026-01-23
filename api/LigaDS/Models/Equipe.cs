using LigaDS.Services;

namespace LigaDS.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LogoUrl { get; set; }
        public int LigaId { get; set; }
    }

    public class TeamData
    {
        public Team Team { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
    }

    public class ApiTeamsResponse
    {
        public Paging Paging { get; set; }
        public List<TeamData> Response { get; set; }
    }
}
