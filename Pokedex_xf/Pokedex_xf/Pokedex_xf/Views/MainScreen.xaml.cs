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
            PokeApiClient pokeApiClient = new PokeApiClient();

            for (int i = 0; i < 10; i++)
            {
                Pokemon pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(index);
                pokeCollection.Add(pokemon);             
                index++;
            }           
        }

        //public void SetTypeColor(Pokemon pokemon)
        //{
        //    if (pokemon.Types[0].Type.Name == "fire")
        //    {
               
        //    }
        //}

        private async void pokeCollectionBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pokemonDetailPage = new PokemonDetailPage(e.CurrentSelection[0] as Pokemon);
            await Navigation.PushAsync(pokemonDetailPage);
        }
    }

}