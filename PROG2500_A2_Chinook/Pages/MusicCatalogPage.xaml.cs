using Microsoft.EntityFrameworkCore;
using PROG2500_A2_Chinook.Data;
using PROG2500_A2_Chinook.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PROG2500_A2_Chinook.Pages
{
    public partial class MusicCatalogPage : Page
    {
        private ChinookContext _context = new ChinookContext();
        private CollectionViewSource musicCatalogViewSource = new CollectionViewSource();

        public MusicCatalogPage()
        {
            InitializeComponent();

            // Tie the markup xaml viewsource object to the code behind viewsource object
            musicCatalogViewSource = (CollectionViewSource)FindResource(nameof(musicCatalogViewSource));

            // Use the dbContext to load the music data we want to display
            _context.Artists.Load();
            _context.Albums.Load();
            _context.Tracks.Load();

            // Set the viewsource data source to use the tracks data collection
            musicCatalogViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        }

        // Optional: Handle search functionality to filter the catalog
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from artist in _context.Artists
                where artist.Name.Contains(searchBox.Text)
                group artist by artist.Name.ToUpper().Substring(0, 1) into artistGroup
                select new
                {
                    Index = artistGroup.Key,
                    ArtistCount = artistGroup.Count().ToString(),
                    artist = artistGroup.ToList<Artist>()
                };

            musicCatalogListView.ItemsSource = query.ToList();
        }
    }
}