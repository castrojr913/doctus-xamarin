using System;
using Autofac;

namespace TipsExam.Dependency
{
    /// <summary>
    /// App module.
    /// </summary>
    public class AppModule
    {

        public IContainer GetIoC()
        {
            var builder = new ContainerBuilder();

            // Modules
            var modelModule = new ModelModule();

            // Register Builder
            modelModule.Register(builder);

            // Register Modules
            builder.RegisterModule(modelModule);

            // Build
            return builder.Build();
        }

    }
}
