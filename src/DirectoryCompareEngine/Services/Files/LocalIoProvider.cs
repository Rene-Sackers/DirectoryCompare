using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files
{
    public class LocalIoProvider : ILocalIoProvider
    {
        public char PathSeparator => '\\';

        public string RootAbsolutePath { get; }

        public LocalIoProvider(string rootAbsolutePath)
        {
            RootAbsolutePath = rootAbsolutePath;
        }

        public string GetRelativePath(string absolutePath)
        {
            if (absolutePath.IndexOf(RootAbsolutePath, 0, StringComparison.Ordinal) != 0)
                throw new InvalidOperationException($"The given local absolute path \"{absolutePath}\" does not reside in the {nameof(LocalIoProvider)} its {nameof(RootAbsolutePath)}");

            return absolutePath.Replace(RootAbsolutePath, "").TrimStart(PathSeparator);
        }

        public IEnumerable<IIoItem> GetDirectoryItems(string absolutePath)
        {
            throw new NotImplementedException();
            //if (!Directory.Exists(absolutePath))
            //    throw new InvalidOperationException($"The given local absolute \"{absolutePath}\" does not exist.");

            //var directoryInfo = new DirectoryInfo(absolutePath);
            //var ioFileItems = directoryInfo
            //    .GetFiles()
            //    .ToList()
            //    .ForEach(fileInfo => new IoFile(true, fileInfo.Name, fileInfo.Length, ));
        }
    }
}