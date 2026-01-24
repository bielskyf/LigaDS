using LigaDS.Services;

namespace LigaDS.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Nacionalidade { get; set; }
        public string FotoUrl { get; set; }
        public string Posicao { get; set; }
        public int Overall { get; set; }
        public int EquipeId { get; set; }
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
