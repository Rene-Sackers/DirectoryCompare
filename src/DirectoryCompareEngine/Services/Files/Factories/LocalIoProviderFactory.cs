using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryCompareEngine.Services.Files.Factories.Interfaces;
using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files.Factories
{
    class LocalIoProviderFactory : Interfaces.ILocalIoProviderFactory
    {
        public IIoProvider Create(string absolutePath)
        {
            return new LocalIoProvider(absolutePath);
        }
    }
}
