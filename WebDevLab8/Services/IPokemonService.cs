using System.Collections.Generic;
using WebDevProject.Models.View;

namespace WebDevProject.Services
{
    public interface IPokemonService
    {
        PokemonViewModel GetPokemon(int id);

        IEnumerable<PokemonViewModel> GetPokemonsForUser(string userId);

        void SavePokemon(string userId, PokemonViewModel pokemon);

        void UpdatePokemon(PokemonViewModel user);

        void DeletePokemon(int id);
    }
}
