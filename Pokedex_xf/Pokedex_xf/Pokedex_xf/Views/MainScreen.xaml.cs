using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApiNet;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Pokedex_xf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreen : ContentPage
    {
        public MainScreen()
        {
            InitializeComponent();
            GetPokemonData();
            pokeCollectionBinding.ItemsSource = pokeCollection;
        }

        ObservableCollection<Pokemon> pokeCollection = new ObservableCollection<Pokemon>();

        private int index = 1;
        private async void GetPokemonData()
        {
            PokeApiClient pokeApiClient = new PokeApiClient();

            for (int i = 0; i < 151; i++)
            {
                Pokemon pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(index);
                pokeCollection.Add(pokemon);
                index++;
            }           
        }

        private async void pokeCollectionBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pokemonDetailPage = new PokemonDetailPage(e.CurrentSelection[0] as Pokemon);
            await Navigation.PushAsync(pokemonDetailPage);
        }

        private void pokeSearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string keyword = pokeSearch.Text;

            if (keyword == "all")
            {
                pokeCollectionBinding.ItemsSource = pokeCollection;
            }
            else
            {
                IEnumerable<Pokemon> searchResult = from pokemon
                                                    in pokeCollection
                                                    where pokemon.Name.ToLower().Contains(keyword.ToLower()) || pokemon.Id.ToString().Equals(keyword)
                                                    select pokemon;

                pokeCollectionBinding.ItemsSource = searchResult;
            }          
        }
    }
}