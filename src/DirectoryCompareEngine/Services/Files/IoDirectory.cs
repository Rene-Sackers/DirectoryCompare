using System.Collections.Generic;
using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files
{
    public class IoDirectory : IIoDirectory
    {
        public bool Exists { get; set; }

        public string Name { get; set; }

        public string RelativePath { get; set; }

        public string AbsolutePath { get; set; }

        public IEnumerable<IIoItem> Children { get; set; }

        public IoDirectory(
            bool exists,
            string name,
            string relativePath,
            string absolutePath,
            IEnumerable<IIoItem> children
            )
        {
            Exists = exists;
            Name = name;
            RelativePath = relativePath;
            AbsolutePath = absolutePath;
            Children = children;
        }
    }
}