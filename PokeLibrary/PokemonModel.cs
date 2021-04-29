using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLibrary
{

    public class PokemonModel
    {
        public int id { get; set; }
        public string location_area_encounters { get; set; }
        public string name { get; set; }
        public Sprites sprites { get; set; }
        public Type[] types { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
        public Other other { get; set; }
    }

    public class Other
    {
        public Dream_World dream_world { get; set; }
        public OfficialArtwork officialartwork { get; set; }
    }

    public class Dream_World
    {
        public string front_default { get; set; }
        public object front_female { get; set; }
    }

    public class OfficialArtwork
    {
        public string front_default { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
