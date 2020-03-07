using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Pokedex_xf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreen : ContentPage
    {
        public MainScreen()
        {
            InitializeComponent();
            pokeCollectionBinding.ItemsSource = pokeCollection;
        }

        ObservableCollection<Pokemon> pokeCollection = new ObservableCollection<Pokemon>()
        {
            new Pokemon { Id = 1, Name = "Bulbasaur" },
            new Pokemon { Id = 2, Name = "Pikachu" },
            new Pokemon { Id = 10, Name = "Kakuna" }
        };

    }

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}