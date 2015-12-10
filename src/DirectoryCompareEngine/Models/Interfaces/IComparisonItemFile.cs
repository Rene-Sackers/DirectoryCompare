namespace DirectoryCompareEngine.Models.Interfaces
{
    public interface IComparisonItemFile : IComparisonItem
    {
        ulong Size { get; }
    }
}
