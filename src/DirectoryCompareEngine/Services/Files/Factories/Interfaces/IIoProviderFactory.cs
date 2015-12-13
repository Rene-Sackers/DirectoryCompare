using DirectoryCompareEngine.Services.Files.Interfaces;

namespace DirectoryCompareEngine.Services.Files.Factories.Interfaces
{
    public interface IIoProviderFactory
    {
        IIoProvider Create(string rootAbsolutePath);
    }
}
