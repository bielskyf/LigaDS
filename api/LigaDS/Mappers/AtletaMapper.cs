using LigaDS.Models;
using Sprache;

namespace LigaDS.Mappers
{
    public static class AtletaMapper
    {
        public static Atleta ToAtletaModel(PlayerFetchDTO playerDTO)
        {
            return new Atleta
            {
                Id = playerDTO.Player.Id,
                Nome = playerDTO.Player.Name,
                Idade = playerDTO.Player.Age,
                Nacionalidade = playerDTO.Player.Nationality,
                FotoUrl = playerDTO.Player.Photo,
            };
        }
    }
}
