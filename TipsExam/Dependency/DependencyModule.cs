using System;
using Autofac;

namespace TipsExam.Dependency
{
    /// <summary>
    /// Dependency module.
    /// </summary>
    public abstract class DependencyModule : Module
    {

        /// <summary>
        /// Register the specified builder.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public abstract void Register(ContainerBuilder builder);

    }
}
