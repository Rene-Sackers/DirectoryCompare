using DirectoryCompareEngine.Models.Interfaces;

namespace DirectoryCompareEngine.Models.Abstracts
{
    public abstract class ComparisonInstanceAbastract
    {
        public IComparisonSideProvider LeftComparisonSideProvider { get; private set; }
        public IComparisonSideProvider RightComparisonSideProvider { get; private set; }

        public IComparisonItemContainer RootContainer { get; }

        protected ComparisonInstanceAbastract(IComparisonSideProvider leftSideProvider, IComparisonSideProvider rightSideProvider)
        {
            LeftComparisonSideProvider = leftSideProvider;
            RightComparisonSideProvider = rightSideProvider;
        }
    }
}
