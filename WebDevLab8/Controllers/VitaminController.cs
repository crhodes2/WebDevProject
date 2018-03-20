using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebDevProject.Data;
using WebDevProject.Data.Entities;
using WebDevProject.Models.View;

namespace WebDevProject.Controllers
{
    public class VitaminController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VitaminViewModel vitaminViewModel)
        {
            if (ModelState.IsValid)
            {
                var vitamin = MapTovitamin(vitaminViewModel);

                Save(vitamin);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult List()
        {
            var vitamins = GetAllvitamins();

            return View(vitamins);
        }

        public ActionResult Delete(int id)
        {
            Deletevitamin(id);

            return RedirectToAction("List");
        }

        //private void Save(vitamin vitamin)
        //{
        //    vitamin.Id = InMemoryDatabase.NextId();
        //    InMemoryDatabase.vitamins.Add(vitamin);
        //}

        private void Save(Vitamins vitamin)
        {
            var dbContext = new AppDbContext();

            dbContext.Vitamins.Add(vitamin);

            dbContext.SaveChanges();
        }

        //private IEnumerable<vitaminViewModel> GetAllvitamins()
        //{
        //    var vitaminViewModels = new List<vitaminViewModel>();

        //    var vitamins = InMemoryDatabase.vitamins;
        //    foreach (var vitamin in vitamins)
        //    {
        //        var vitaminViewModel = MapTovitaminViewModel(vitamin);
        //        vitaminViewModels.Add(vitaminViewModel);
        //    }

        //    return vitaminViewModels;
        //}

        private IEnumerable<VitaminViewModel> GetAllvitamins()
        {
            var vitaminViewModels = new List<VitaminViewModel>();

            var dbContext = new AppDbContext();

            var vitamins = dbContext.Vitamins;

            foreach (var vitamin in vitamins)
            {
                var vitaminViewModel = MapTovitaminViewModel(vitamin);
                vitaminViewModels.Add(vitaminViewModel);
            }

            return vitaminViewModels;
        }

        //private void Deletevitamin(int id)
        //{
        //    InMemoryDatabase.Deletevitamin(id);
        //}

        private void Deletevitamin(int id)
        {
            var dbContext = new AppDbContext();

            var vitamins = dbContext.Vitamins;

            var vitamin = vitamins.SingleOrDefault(u => u.VitId == id);

            if (vitamin != null)
            {
                dbContext.Vitamins.Remove(vitamin);
                dbContext.SaveChanges();
            }
        }

        private Vitamins MapTovitamin(VitaminViewModel vitaminViewModel)
        {
            return new Vitamins
            {
            VitId = vitaminViewModel.VitId,
            VitaminName = vitaminViewModel.VitaminName,
            ServingSize= vitaminViewModel.ServingSize,
            AboutVitamin= vitaminViewModel.AboutVitamin,
            RefillDate= vitaminViewModel.RefillDate,
            PokemonId = vitaminViewModel.PokemonId,
            };
        }

        private VitaminViewModel MapTovitaminViewModel(Vitamins vitamin)
        {
            return new VitaminViewModel
            {
                VitId = vitamin.VitId,
                VitaminName = vitamin.VitaminName,
                ServingSize = vitamin.ServingSize,
                AboutVitamin = vitamin.AboutVitamin,
                RefillDate = vitamin.RefillDate,
                PokemonId = vitamin.PokemonId
            };
        }
    }
}