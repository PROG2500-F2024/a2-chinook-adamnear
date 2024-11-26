/*using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PROG2500_A2_Chinook.Data;
using System.Linq;

namespace PROG2500_A2_Chinook.Models.Generated
{
    public class MusicCatalog : INotifyPropertyChanged
    {
        private ObservableCollection<ArtistGroup> _artistGroups;
        public ObservableCollection<ArtistGroup> ArtistGroups
        {
            get => _artistGroups;
            set
            {
                _artistGroups = value;
                OnPropertyChanged();
            }
        }

        public MusicCatalog()
        {
            using (var context = new ChinookContext())
            {
                // Grouping artists by the first letter of their name and getting counts
                var artistGroupings = context.Artists
                    .GroupBy(a => a.Name[0].ToString().ToUpper())  // Group by first letter
                    .Select(g => new ArtistGroup
                    {
                        FirstLetter = g.Key,
                        //Artists = g.ToList(),
                        ArtistCount = g.Count(),
                        IsExpanded = false  // Initial state: collapsed
                    })
                    .OrderBy(g => g.FirstLetter)  // Optionally, sort by letter
                    .ToList();

                ArtistGroups = new ObservableCollection<ArtistGroup>(artistGroupings);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ArtistGroup
    {
        public string FirstLetter { get; set; }
        public List<Artist> Artists { get; set; }
        public int ArtistCount { get; set; }
        public bool IsExpanded { get; set; }  // Control expand/collapse for this group
    }

    public class Artist
    {
        public string Name { get; set; }
        public List<Album> Albums { get; set; }  // Artist’s albums
    }

    public class Album
    {
        public string Title { get; set; }
        public List<Track> Tracks { get; set; }  // Album’s tracks
    }

    public class Track
    {
        public string Name { get; set; }
    }
}*/