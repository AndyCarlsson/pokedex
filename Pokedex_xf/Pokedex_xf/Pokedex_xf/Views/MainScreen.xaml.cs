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
        //{
        //    new Pokemon { Id = 1, Name = "Bulbasaur", Type= "Grass" },
        //    new Pokemon { Id = 2, Name = "Pikachu", Type = "Electric"},
        //    new Pokemon { Id = 10, Name = "Kakuna", Type = "Bug"}
        //};


        private async void GetPokemonData()
        {
            PokeApiClient pokeClient = new PokeApiClient();

            Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(1);
            pokeCollection.Add(pokemon);
        }
        


        //private async void pokeCollectionBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var pokemonDetailPage = new PokemonDetailPage(e.CurrentSelection[0] as Pokemon);
        //    await Navigation.PushAsync(pokemonDetailPage);
        //}
    }



    //public class Pokemon
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Type { get; set; }
    //}
}