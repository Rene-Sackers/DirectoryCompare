using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DirectoryCompareEngine
{
    public class DefaultWiringModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (DefaultWiringModule).Assembly).AsImplementedInterfaces();
        }
    }
}
