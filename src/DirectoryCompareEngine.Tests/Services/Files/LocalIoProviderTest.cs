using Autofac;
using DirectoryCompareEngine.Services.Files.Factories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirectoryCompareEngine.Tests.Services.Files
{
    [TestClass]
    public class LocalIoProviderTest : TestBase
    {
        [TestMethod]
        public void GetRelativePathTest()
        {
            var container = CreateContainer();

            var factory = container.Resolve<ILocalIoProviderFactory>();
            var provider = factory.Create("foobar");
        }
    }
}
