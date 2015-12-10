using System.Collections.ObjectModel;

namespace DirectoryCompareEngine.Models.Interfaces
{
    public interface IComparisonItemContainer : IComparisonItem
    {
        ObservableCollection<IComparisonItem> SubItems { get; }
    }
}
