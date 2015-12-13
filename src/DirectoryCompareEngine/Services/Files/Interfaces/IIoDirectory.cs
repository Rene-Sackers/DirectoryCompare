using System.Collections.Generic;

namespace DirectoryCompareEngine.Services.Files.Interfaces
{
    public interface IIoDirectory  : IIoItem
	{
		IEnumerable<IIoItem> Children { get;set; }

	}
}

