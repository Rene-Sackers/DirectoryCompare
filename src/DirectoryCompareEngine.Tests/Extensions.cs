using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using NSubstitute;

namespace DirectoryCompareEngine.Tests
{

    public static class Extensions
    {
        private static readonly IDictionary<Type, object> FakeCache = new Dictionary<Type, object>();

        internal static void ClearCache()
        {
            FakeCache.Clear();
        }

        public static TInterface RegisterFake<TInterface>(this ContainerBuilder builder)
            where TInterface : class
        {
            if (FakeCache.ContainsKey(typeof(TInterface)))
            {
                return (TInterface)FakeCache[typeof(TInterface)];
            }

            var fake = Substitute.For<TInterface>();
            FakeCache.Add(typeof(TInterface), fake);
            builder.RegisterInstance(fake);
            return fake;
        }

        public static void IgnoreAwait(this Task task) { }
    }
}
