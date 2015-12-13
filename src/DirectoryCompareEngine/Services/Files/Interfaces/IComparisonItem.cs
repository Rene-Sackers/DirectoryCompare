namespace DirectoryCompareEngine.Services.Files.Interfaces
{
    public interface IComparisonItem 
	{
		IIoItem LeftIoItem { get;set; }

		IIoItem RightIoItem { get;set; }

	}
}

