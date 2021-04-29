using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokeLibrary
{
    public class PokeProcessor
    {
        public static async Task<PokemonModel> LoadPokemon(string pokemonName = "1")
        {
            string numericString = string.Empty;
            string url = "";

            if(int.TryParse(numericString, System.Globalization.NumberStyles.Integer, null, out int i))
            {
                if (i > 1)
                {
                    url = $"https://pokeapi.co/api/v2/pokemon/{i}";
                }
                else
                {
                    url = "https://pokeapi.co/api/v2/pokemon/1";
                }
            }
            else
            {
                url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";
            }

            

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    PokemonModel pokemon = await response.Content.ReadAsAsync<PokemonModel>();

                    return pokemon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<TypeModel> LoadType(string pokemonType = "1")
        {
            string numericString = string.Empty;
            string url = "";

            if (int.TryParse(numericString, System.Globalization.NumberStyles.Integer, null, out int i))
            {
                if (i > 1)
                {
                    url = $"https://pokeapi.co/api/v2/type/{i}";
                }
                else
                {
                    url = "https://pokeapi.co/api/v2/type/1";
                }
            }
            else
            {
                url = $"https://pokeapi.co/api/v2/type/{pokemonType}";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TypeModel type = await response.Content.ReadAsAsync<TypeModel>();

                    return type;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
