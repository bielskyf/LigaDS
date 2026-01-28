using System.ComponentModel.DataAnnotations.Schema;

namespace LigaDS.Models
{
    [Table("liga")]
    public class Liga
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
    }

    public class League
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class LeagueFetchDTO
    {
        public League League { get; set; }
    }

    public class ApiLeaguesResponse
    {
        public Paging Paging { get; set; }
        public List<LeagueFetchDTO> Response { get; set; }
    }
}
