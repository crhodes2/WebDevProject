using System.Collections.Generic;
using System.Linq;
using WebDevProject.Data.Entities;
using WebDevProject.Models;

namespace WebDevProject.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDbContext _dbContext;

        public PokemonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pokemon GetPokemon(int id)
        {
            return _dbContext.Pokemons.Find(id);
        }

        public IEnumerable<Pokemon> GetPokemonsForUser(string userId)
        {
            return _dbContext.Pokemons.Where(pokemon => pokemon.UserId == userId).ToList();
        }

        public void SavePokemon(Pokemon pokemon)
        {
            _dbContext.Pokemons.Add(pokemon);

            _dbContext.SaveChanges();
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            _dbContext.SaveChanges();
        }

        public void DeletePokemon(int id)
        {
            var pokemon = _dbContext.Pokemons.Find(id);

            if (pokemon == null) return;

            _dbContext.Pokemons.Remove(pokemon);
            _dbContext.SaveChanges();
        }
    }
}