using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDevProject.Data.Entities;

namespace WebDevProject.Databases
{

    public class InMemoryDatabase
    {
        public static List<Pokemon> Pokemon = new List<Pokemon>();
        public static List<Vitamins> Vitamins = new List<Vitamins>();

    }
}