using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files.Factories
{
    public class LocalIoProviderFactory : Interfaces.ILocalIoProviderFactory
    {
        public IIoProvider Create(string rootAbsolutePath)
        {
            return new LocalIoProvider(rootAbsolutePath);
        }
    }
}
