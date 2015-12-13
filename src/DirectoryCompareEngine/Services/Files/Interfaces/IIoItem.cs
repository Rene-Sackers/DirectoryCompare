namespace DirectoryCompareEngine.Services.Files.Interfaces
{
    public interface IIoItem 
	{
		bool Exists { get; set; }

		string Name { get; set; }

        string RelativePath { get; set; }

        string AbsolutePath { get; set; }
	}
}

