using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDevProject.Data;
using WebDevProject.Data.Entities;
using WebDevProject.Models.View;

namespace WebDevProject.Controllers
{
    public class VitaminsController : Controller
    {
        public ActionResult List(int pokemonId)
        {
            ViewBag.PokemonId = pokemonId;

            var vitamins = GetVitForPokemon(pokemonId);

            return View(vitamins);
        }

        [HttpGet]
        public ActionResult Create(int pokemonId)
        {
            ViewBag.PokemonId = pokemonId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(VitaminsViewModel vitaminViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(vitaminViewModel);
                return RedirectToAction("List", new { UserId = vitaminViewModel.PokemonId});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vitamin = GetVitamins(id);

            return View(vitamin);
        }

        [HttpPost]
        public ActionResult Edit(VitaminsViewModel vitaminViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateVitamin(vitaminViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var vitamin = GetVitamins(id);

            DeleteVitamin(id);

            return RedirectToAction("List", new { PokemonId = vitamin.PokemonId });
        }

        private Vitamins GetVitamins(int vitId)
        {
            var dbContext = new AppDbContext();

            return dbContext.Vitamins.Find(vitId);
        }

        private ICollection<VitaminsViewModel> GetVitForPokemon(int pokemonId)
        {
            var vitaminsViewModels = new List<VitaminsViewModel>();

            var dbContext = new AppDbContext();

            var vitamins = dbContext.Vitamins.Where(vitamin => vitamin.PokemonId == pokemonId).ToList();

            foreach (var vitamin in vitamins)
            {
                var vitaminViewModel = MapToVitaminsViewModel(vitamin);
                vitaminsViewModels.Add(vitaminViewModel);
            }

            return vitaminsViewModels;
        }

        private void Save(VitaminsViewModel vitaminViewModel)
        {
            var dbContext = new AppDbContext();

            var vitamin = MapToVitamins(vitaminViewModel);

            dbContext.Vitamins.Add(vitamin);

            dbContext.SaveChanges();
        }

        private void UpdateVitamin(VitaminsViewModel vitaminViewModel)
        {
            var dbContext = new AppDbContext();

            var vitamin = dbContext.Vitamins.Find(vitaminViewModel.VitId);

            CopyToVitamin(vitaminViewModel, vitamin);

            dbContext.SaveChanges();
        }

        private void DeleteVitamin(int id)
        {
            var dbContext = new AppDbContext();

            var vitamin = dbContext.Vitamins.Find(id);

            if (vitamin != null)
            {
                dbContext.Vitamins.Remove(vitamin);
                dbContext.SaveChanges();
            }
        }

        private Vitamins MapToVitamins(VitaminsViewModel vitaminViewModel)
        {
            return new Vitamins
            {
                VitId = vitaminViewModel.VitId,
                VitaminName = vitaminViewModel.VitaminName,
                ServingSize = vitaminViewModel.ServingSize,
                AboutVitamin = vitaminViewModel.AboutVitamin,
                RefillDate = vitaminViewModel.RefillDate,
                PokemonId = vitaminViewModel.PokemonId
            };
        }

        private VitaminsViewModel MapToVitaminsViewModel(Vitamins vitamin)
        {
            return new VitaminsViewModel
            {
                VitId = vitamin.VitId,
                VitaminName = vitamin.VitaminName,
                ServingSize = vitamin.ServingSize,
                AboutVitamin = vitamin.AboutVitamin,
                RefillDate = vitamin.RefillDate,
                PokemonId = vitamin.PokemonId
            };
        }

        private void CopyToVitamin(VitaminsViewModel vitaminViewModel, Vitamins vitamin)
        {
            vitamin.VitId = vitaminViewModel.VitId;
            vitamin.VitaminName = vitaminViewModel.VitaminName;
            vitamin.ServingSize= vitaminViewModel.ServingSize;
            vitamin.AboutVitamin= vitaminViewModel.AboutVitamin;
            vitamin.RefillDate= vitaminViewModel.RefillDate;
            vitamin.PokemonId = vitaminViewModel.PokemonId;
        }
    }
}