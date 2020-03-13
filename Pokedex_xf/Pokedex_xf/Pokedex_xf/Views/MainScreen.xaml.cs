using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokeApiNet;


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
            PokeApiClient pokeClient = new PokeApiClient();
        
            for (int i = 0; i < 10; i++)
            {
                Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(index);
                pokeCollection.Add(pokemon);
                index++;
            }           
        }


        private async void pokeCollectionBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pokemonDetailPage = new PokemonDetailPage(e.CurrentSelection[0] as Pokemon);
            await Navigation.PushAsync(pokemonDetailPage);
        }
    }



    //public class Pokemon
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //}
}