using System;
using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files
{
    public class IoFile : IIoFile
    {
        public bool Exists { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string RelativePath { get; set; }

        public string AbsolutePath { get; set; }

        public IoFile(
            bool exists,
            string name,
            long size,
            string relativePath,
            string absolutePath
            )
        {
            Exists = exists;
            Name = name;
            Size = size;
            RelativePath = relativePath;
            AbsolutePath = absolutePath;
        }
    }
}
