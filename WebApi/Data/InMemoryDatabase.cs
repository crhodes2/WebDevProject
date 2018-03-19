using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class InMemoryDatabase
    {
        public static List<Pokemon> Pokemons;

        static InMemoryDatabase()
        {
            Pokemons = new List<Pokemon>
            {
                new Pokemon
                {
                    Id = 1,
                    Name = "Charizard",
                    Age = 16,
                    NextCheckup = DateTime.Parse("3/26/2018"),
                    VetName = "Joy"
                },

                new Pokemon
                {
                    Id = 2,
                    Name = "Greninja",
                    Age = 12,
                    NextCheckup = DateTime.Parse("3/26/2018"),
                    VetName = "Joy"

                },

                new Pokemon
                {
                    Id = 3,
                    Name = "Wigglytuff",
                    Age = 34,
                    NextCheckup = DateTime.Parse("3/26/2018"),
                    VetName = "Joy"
                },

                new Pokemon
                {
                    Id = 4,
                    Name = "Absol",
                    Age = 45,
                    NextCheckup = DateTime.Parse("3/26/2018"),
                    VetName = "Joy"

                },
            };
        }
    }


}