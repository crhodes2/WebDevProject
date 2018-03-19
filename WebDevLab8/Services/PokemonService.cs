using System;
using System.Collections.Generic;
using WebDevProject.Data.Entities;
using WebDevProject.Models.View;
using WebDevProject.Repositories;

namespace WebDevProject.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _repository;

        public PokemonService(IPokemonRepository respository)
        {
            _repository = respository;
        }

        public PokemonViewModel GetPokemon(int id)
        {
            var pokemon = _repository.GetPokemon(id);
            return MapToPokemonViewModel(pokemon);
        }

        public IEnumerable<PokemonViewModel> GetPokemonsForUser(string userId)
        {
            var pokemonViewModels = new List<PokemonViewModel>();

            var pokemons = _repository.GetPokemonsForUser(userId);

            foreach (var pokemon in pokemons)
            {
                pokemonViewModels.Add(MapToPokemonViewModel(pokemon));
            }

            return pokemonViewModels;
        }

        public void SavePokemon(string userId, PokemonViewModel pokemonViewModel)
        {
            //throw new Exception("Test Exception");

            var pokemon = MapToPokemon(userId, pokemonViewModel);

            _repository.SavePokemon(pokemon);
        }

        public void UpdatePokemon(PokemonViewModel pokemonViewModel)
        {
            var pokemon = _repository.GetPokemon(pokemonViewModel.Id);

            CopyToPokemon(pokemonViewModel, pokemon);

            _repository.UpdatePokemon(pokemon);
        }

        public void DeletePokemon(int id)
        {
            _repository.DeletePokemon(id);
        }

        private Pokemon MapToPokemon(string userId, PokemonViewModel pokemonViewModel)
        {
            return new Pokemon
            {
                Id = pokemonViewModel.Id,
                Name = pokemonViewModel.Name,
                Age = pokemonViewModel.Age,
                NextCheckup = pokemonViewModel.NextCheckup,
                VetName = pokemonViewModel.VetName,
                UserId = userId
            };
        }

        private PokemonViewModel MapToPokemonViewModel(Pokemon pokemon)
        {
            var pokemonViewModel = new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Age = pokemon.Age,
                NextCheckup = pokemon.NextCheckup,
                VetName = pokemon.VetName
            };

            pokemonViewModel.CheckupAlert = (pokemonViewModel.NextCheckup - DateTime.Now).Days < 14;

            return pokemonViewModel;
        }

        private void CopyToPokemon(PokemonViewModel pokemonViewModel, Pokemon pokemon)
        {
            pokemon.Id = pokemonViewModel.Id;
            pokemon.Name = pokemonViewModel.Name;
            pokemon.Age = pokemonViewModel.Age;
            pokemon.NextCheckup = pokemonViewModel.NextCheckup;
            pokemon.VetName = pokemonViewModel.VetName;
        }
    }
}