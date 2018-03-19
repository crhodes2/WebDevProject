using System;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using WebDevProject.Models.View;
using WebDevProject.Services;

namespace WebDevProject.Controllers
{
    [Authorize]
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly ILog _log = LogManager.GetLogger(typeof(PokemonController));

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        
        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            _log.Debug("Getting list of pokemons for user: " + userId);

            var pokemonViewModels = _pokemonService.GetPokemonsForUser(userId);

            return View(pokemonViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PokemonViewModel pokemonViewModel)
        {
            _log.Info("Creating pokemon");

            if (!ModelState.IsValid) return View();

            try
            {
                var userId = User.Identity.GetUserId();
                _pokemonService.SavePokemon(userId, pokemonViewModel);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to save pokemon.", ex);
                throw;
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pokemon = _pokemonService.GetPokemon(id);

            return View(pokemon);
        }

        [HttpPost]
        public ActionResult Edit(PokemonViewModel pokemonViewModel)
        {
            if (ModelState.IsValid)
            {
                _pokemonService.UpdatePokemon(pokemonViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var pokemon = _pokemonService.GetPokemon(id);

            return View(pokemon);
        }
        
        public ActionResult Delete(int id)
        {
            _pokemonService.DeletePokemon(id);

            return RedirectToAction("List");
        }
    }
}