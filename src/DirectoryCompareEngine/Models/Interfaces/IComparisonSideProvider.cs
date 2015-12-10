using System.Collections.Generic;

namespace DirectoryCompareEngine.Models.Interfaces
{
    public interface IComparisonSideProvider
    {
        string PathSeparator { get; }
        string AbsoluteRootPath { get; }

        void UploadItem(IComparisonItem sourceComparisonItem, IComparisonItemContainer targetItemContainer);
        void DownloadItem(IComparisonItem sourceComparisonItem, IComparisonItemContainer targetItemContainer);
        IEnumerable<IComparisonItem> GetContainerChildren(IComparisonItemContainer container);
        ulong GetFileSize(IComparisonItemFile file);
    }
}
