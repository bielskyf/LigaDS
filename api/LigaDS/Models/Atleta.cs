using LigaDS.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace LigaDS.Models
{
    [Table("atleta")]
    public class Atleta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("idade")]
        public int Idade { get; set; }

        [Column("nacionalidade")]
        public string Nacionalidade { get; set; }

        [Column("foto_url")]
        public string FotoUrl { get; set; }

        [Column("posicao")]
        public string Posicao { get; set; }

        [Column("overall")]
        public int Overall { get; set; }

        [Column("equipe_id")]
        public int EquipeId { get; set; }

        [Column("liga_id")]
        public int LigaId { get; set; }
    }

    public class PlayerFetchDTO
    { 
        public Player Player { get; set; }
        public List<Statistics> Statistics { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Nationality { get; set; }
        public string? Photo { get; set; }
    }

    public class Statistics
    {
        public Team Team { get; set; }
        public League League { get; set; }
        public Games Games { get; set; }
    }

    public class Games
    {
        public string? Position { get; set; }
        public int? Rating { get; set; }
    }
    
    public class ApiPlayersResponse
    {
        public Paging Paging { get; set; }
        public List<PlayerFetchDTO> Response { get; set; }
    }
}
