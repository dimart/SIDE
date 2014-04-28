using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace Side.Interfaces
{
    public interface IWorkspace
    {
        ObservableCollection<ContentViewModel> Documents { get; set; }
        ContentViewModel ActiveDocument { get; set; }
        string Title { get; }
    }
}
