using System.Collections.ObjectModel;
using Side.Core.CodeBox;

namespace Side.Interfaces
{
    public interface IWorkspace
    {
        ObservableCollection<CodeViewModel> Documents { get; set; }
        CodeViewModel ActiveDocument { get; set; }

        string Title { get; }
    }
}
