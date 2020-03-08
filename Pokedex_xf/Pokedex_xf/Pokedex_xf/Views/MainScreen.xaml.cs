using System;
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
            new Pokemon { Id = 1, Name = "Bulbasaur", Type= "Grass" },
            new Pokemon { Id = 2, Name = "Pikachu", Type = "Electric"},
            new Pokemon { Id = 10, Name = "Kakuna", Type = "Bug"}
        };

        public void changeBgColor()
        {
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
          
        }
    }



    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}