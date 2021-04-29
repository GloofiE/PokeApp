using PokeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxPokeID = 898;
        private int currentID = 1;
        private string[] pokeTypes = { null, null };
        
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            previousPokemonButton.IsEnabled = false;
            nextPokemonButton.IsEnabled = false;
        }

        private async Task LoadImage(string pokemonName = "")
        {
            var pokemon = await PokeProcessor.LoadPokemon(pokemonName);

            currentID = pokemon.id;

            pokeTypes[0] = "";
            pokeTypes[1] = "";

            string typeString = "";

            for (int i = 0; i < pokemon.types.Length; i++)
            {
                pokeTypes[i] = pokemon.types[i].type.name;
                if (i > 0)
                {
                    typeString = typeString + ", ";
                }
                typeString = typeString + pokemon.types[i].type.name;
            }

            var uriImg = new Uri(pokemon.sprites.front_default, UriKind.Absolute);
            pokemonImage.Source = new BitmapImage(uriImg);
            nameLine.Text = pokemon.name.Substring(0, 1).ToUpper() + pokemon.name.Substring(1, pokemon.name.Length - 1);
            idLine.Text = "ID: " + currentID.ToString();
            typeLine.Text = "Type(s): " + typeString;
        }

        private async Task LoadData(string pokemonType = "", string pokemonType2 = "")
        {
            List<TypeModel> typeModels = new List<TypeModel>();
            List<String> ddt = new List<string>();
            List<String> ndt = new List<string>();
            List<String> ddf = new List<string>();
            List<String> hdf = new List<string>();
            List<String> ndf = new List<string>();
            var type = await PokeProcessor.LoadType(pokemonType);
            typeModels.Add(type);
            pokeTypes[0] = type.name;
            if (pokemonType2 != "")
            {
                var type2 = await PokeProcessor.LoadType(pokemonType2);
                typeModels.Add(type2);
                pokeTypes[1] = type2.name;
            }
            for(int i = 0; i < typeModels.Count; i++)
            {
                Damage_Relations dr = typeModels[i].damage_relations;
                if (dr.double_damage_to != null)
                {
                    for(int j = 0; j < dr.double_damage_to.Length; j++)
                    {
                        ddt.Add(dr.double_damage_to[j].name);
                    }
                }
                else
                {
                    ddt.Add("(none)");
                }
                if (dr.no_damage_to != null)
                {
                    for (int j = 0; j < dr.no_damage_to.Length; j++)
                    {
                        ndt.Add(dr.no_damage_to[j].name);
                    }
                }
                else
                {
                    ndt.Add("none");
                }
                if (dr.double_damage_from != null)
                {
                    for (int j = 0; j < dr.double_damage_from.Length; j++)
                    {
                        ddf.Add(dr.double_damage_from[j].name);
                    }
                }
                else
                {
                    ddf.Add("(none)");
                }
                if (dr.half_damage_from != null)
                {
                    for (int j = 0; j < dr.half_damage_from.Length; j++)
                    {
                        hdf.Add(dr.half_damage_from[j].name);
                    }
                }
                else
                {
                    hdf.Add("(none)");
                }
                if (dr.no_damage_from != null)
                {
                    for (int j = 0; j < dr.no_damage_from.Length; j++)
                    {
                        ndf.Add(dr.no_damage_from[j].name);
                    }
                }
                else
                {
                    ndf.Add("(none)");
                }
            }

            string ddtString = string.Join(", ", ddt.Distinct());
            string ndtString = string.Join(", ", ndt.Distinct());
            string ddfString = string.Join(", ", ddf.Distinct());
            string hdfString = string.Join(", ", hdf.Distinct());
            string ndfString = string.Join(", ", ndf.Distinct());

            ddtLine.Text = "Super Effective towards: " + ddtString;
            ndtLine.Text = "No Damage to: " + ndtString;
            ddfLine.Text = "Weak to: " + ddfString;
            hdfLine.Text = "Resistant to: " + hdfString;
            ndfLine.Text = "Immune to: " + ndfString;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage("1");
            await LoadData("12","4");
            if (currentID > 1)
                previousPokemonButton.IsEnabled = true;
            if (currentID < 898)
                nextPokemonButton.IsEnabled = true;
        }

        private async void previousPokemonButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentID>1)
            {
                currentID -= 1;
                nextPokemonButton.IsEnabled = true;
                await LoadImage(currentID.ToString());
                await LoadData(pokeTypes[0], pokeTypes[1]);

                if(currentID == 1)
                {
                    previousPokemonButton.IsEnabled = false;
                }
            }
        }

        private async void nextPokemonButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentID < maxPokeID)
            {
                currentID += 1;
                previousPokemonButton.IsEnabled = true;
                await LoadImage(currentID.ToString());
                await LoadData(pokeTypes[0], pokeTypes[1]);

                if (currentID == maxPokeID)
                {
                    nextPokemonButton.IsEnabled = false;
                }
            }
        }

        private async void selectPokemon_Click(object sender, RoutedEventArgs e)
        {
            string userInput = inputText.Text.ToString();
            try
            {
                await LoadImage(userInput);
            }
            catch
            {
                await LoadImage(currentID.ToString());
            }
            await LoadData(pokeTypes[0], pokeTypes[1]);
            inputText.Text = "";
        }
    }
}
