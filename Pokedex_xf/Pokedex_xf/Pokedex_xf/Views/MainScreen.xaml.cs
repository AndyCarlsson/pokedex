using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            new Pokemon { Id = 1, Name = "Bulbasaur" }
        };



    }

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}