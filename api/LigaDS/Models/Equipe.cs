using LigaDS.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigaDS.Models
{
    [Table("equipe")]
    public class Equipe
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("logo_url")]
        public string LogoUrl { get; set; }

        [Column("liga_id")]
        public int LigaId { get; set; }
    }

    public class TeamFetchDTO
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
        public List<TeamFetchDTO> Response { get; set; }
    }
}
