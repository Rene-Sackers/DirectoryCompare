using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autofac;
using DirectoryCompareEngine.Services.Files.Factories.Interfaces;
using DirectoryCompareEngine.Services.Files.Interfaces;
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

            var rootAbsolutePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var provider = factory.Create(rootAbsolutePath);

            const string relativeSubPath = "Sub folder 1\\Sub folder 2";
            var absoluteSubPath = Path.Combine(rootAbsolutePath, relativeSubPath);

            Assert.AreEqual(provider.GetRelativePath(absoluteSubPath), relativeSubPath + "\\");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetRelativePathThrowsExceptionOnRootMismatch()
        {
            var container = CreateContainer();

            var factory = container.Resolve<ILocalIoProviderFactory>();

            var rootAbsolutePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var provider = factory.Create(rootAbsolutePath);

            var differentRootAbsolutePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            const string relativeSubPath = "Sub folder 1\\Sub folder 2";
            var absoluteSubPath = Path.Combine(differentRootAbsolutePath, relativeSubPath);

            provider.GetRelativePath(absoluteSubPath);
        }

        [TestMethod]
        public void GetDirectoryItemsTest()
        {
            var container = CreateContainer();

            var factory = container.Resolve<ILocalIoProviderFactory>();

            var rootAbsolutePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var provider = factory.Create(rootAbsolutePath);

            var subItems = provider.GetDirectoryItems(rootAbsolutePath).ToArray();
            
            var subDirectoryAbsolutePaths = Directory.GetDirectories(rootAbsolutePath);
            var subFileAbsolutePaths = Directory.GetFiles(rootAbsolutePath);

            foreach (var subDirectoryAbsolutePath in subDirectoryAbsolutePaths)
                Assert.IsTrue(subItems.OfType<IIoDirectory>().Any(ioDirectory => ioDirectory.AbsolutePath == subDirectoryAbsolutePath));

            foreach (var subFileAbsolutePath in subFileAbsolutePaths)
                Assert.IsTrue(subItems.OfType<IIoFile>().Any(ioFile => ioFile.AbsolutePath == subFileAbsolutePath));
        }
    }
}
