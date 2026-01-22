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
}
