using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files.Factories.Interfaces
{
    public interface IIoProviderFactory
    {
        IIoProvider Create(string absolutePath);
    }
}
