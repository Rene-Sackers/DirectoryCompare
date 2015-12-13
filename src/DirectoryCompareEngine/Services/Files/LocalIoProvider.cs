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

            return absolutePath.Replace(RootAbsolutePath, "").TrimStart(PathSeparator).TrimEnd(PathSeparator) + PathSeparator;
        }

        public IEnumerable<IIoItem> GetDirectoryItems(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
                throw new InvalidOperationException($"The given local absolute \"{absolutePath}\" does not exist.");

            var directoryInfo = new DirectoryInfo(absolutePath);
            var ioFileItems = directoryInfo
                .GetFiles()
                .ToList()
                .Select(
                    subFileInfo =>
                    new IoFile(
                        true,
                        subFileInfo.Name,
                        subFileInfo.Length,
                        GetRelativePath(subFileInfo.FullName),
                        subFileInfo.FullName
                    )
                );

            var ioDirectoryItems = directoryInfo
                .GetDirectories()
                .ToList()
                .Select(
                    subDirectoryInfo =>
                    new IoDirectory(
                        true,
                        subDirectoryInfo.Name,
                        GetRelativePath(subDirectoryInfo.FullName),
                        subDirectoryInfo.FullName,
                        GetDirectoryItems(subDirectoryInfo.FullName)
                    )
                );

            return ioFileItems.OfType<IIoItem>().Concat(ioDirectoryItems);
        }
    }
}