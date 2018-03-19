using System.Collections.Generic;
using WebDevProject.Data.Entities;

namespace WebDevProject.Repositories
{
    public interface IPokemonRepository
    {
        Pokemon GetPokemon(int id);

        IEnumerable<Pokemon> GetPokemonsForUser(string userId);

        void SavePokemon(Pokemon pokemon);

        void UpdatePokemon(Pokemon user);

        void DeletePokemon(int id);
    }
}
