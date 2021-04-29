using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLibrary
{
    public class TypeModel
    {
        public Damage_Relations damage_relations { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Pokemon[] pokemon { get; set; }
    }

    public class Damage_Relations
    {
        public Double_Damage_From[] double_damage_from { get; set; }
        public Double_Damage_To[] double_damage_to { get; set; }
        public Half_Damage_From[] half_damage_from { get; set; }
        public Half_Damage_To[] half_damage_to { get; set; }
        public No_Damage_From[] no_damage_from { get; set; }
        public No_Damage_To[] no_damage_to { get; set; }
    }

    public class Double_Damage_From
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Double_Damage_To
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Half_Damage_To
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Half_Damage_From
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class No_Damage_From
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class No_Damage_To
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pokemon
    {
        public Pokemon1 pokemon { get; set; }
        public int slot { get; set; }
    }

    public class Pokemon1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
