using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DirectoryCompareEngine.Services.Files.Interfaces
{
    public interface IIoProvider 
	{
        string GetRelativePath(string absolutePath);

        IEnumerable<IIoItem> GetDirectoryItems(string absolutePath);
	}
}

