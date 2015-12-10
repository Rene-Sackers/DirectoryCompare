using DirectoryCompareEngine.Models.Enums;

namespace DirectoryCompareEngine.Models.Interfaces
{
    public interface IComparisonItem
    {
        IComparisonItem Parent { get; }

        string Name { get; }

        string LeftRelativePath { get; }
        string RightRelativePath { get; }

        string LeftAbsolutePath { get; }
        string RightAbsolutePath { get; }

        IComparisonSideProvider LeftComparisonSideProvider { get; }
        IComparisonSideProvider RightComparisonSideProvider { get; }

        ItemSyncStates LeftSyncState { get; }
        ItemSyncStates RightSyncState { get; }
    }
}
