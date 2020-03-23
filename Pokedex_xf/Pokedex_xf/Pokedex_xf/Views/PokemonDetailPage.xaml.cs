using PokeApiNet;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex_xf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonDetailPage : ContentPage
    {
        public PokemonDetailPage(Pokemon pokemon)
        {
            InitializeComponent();
            GetDetailInfo(pokemon.Id);
            SpriteImage.Source = pokemon.Sprites.FrontDefault;
            NameLabel.Text = pokemon.Name;
            TypeOneLabel.Text = pokemon.Types[0].Type.Name;

            if (pokemon.Types.Count > 1)
            {
                TypeTwoLabel.Text = pokemon.Types[1].Type.Name;
            }
            if (pokemon.Types.Count == 1)
            {
                Grid.SetColumnSpan(TypeOneLabel, 2);
                TypeOneLabel.HorizontalOptions = LayoutOptions.Center;
            }         
        }

        public async void GetDetailInfo(int id)
        {
            PokeApiClient pokeApiClient = new PokeApiClient();

            var detail = await pokeApiClient.GetResourceAsync<PokemonSpecies>(id);

            foreach (var entry in detail.FlavorTextEntries)
            {
                if (detail.FlavorTextEntries[1].Language.Name == "en")
                {
                    DescLabel.Text = "\u0022" + $"{ detail.FlavorTextEntries[1].FlavorText}" + "\u0022";
                }
                else
                {
                    DescLabel.Text = "\u0022" + $"{ detail.FlavorTextEntries[2].FlavorText}" + "\u0022";
                }
            }
        }
    }
}