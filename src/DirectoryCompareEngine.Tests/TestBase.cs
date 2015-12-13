using System;
using Autofac;

namespace DirectoryCompareEngine.Tests
{
    public class TestBase
    {
        protected ILifetimeScope CreateContainer(Action<ContainerBuilder> setupCallback = null)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DefaultWiringModule());

            setupCallback?.Invoke(builder);

            return builder.Build();
        }
    }
}
