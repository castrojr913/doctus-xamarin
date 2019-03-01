using System;
using Autofac;
using TipsExam.Model.Domain;
using TipsExam.Model.Infrastructure;

namespace TipsExam.Dependency
{
    /// <summary>
    /// View model module.
    /// </summary>
    public class ModelModule : DependencyModule
    {
        ///<inheritdoc/>
        public override void Register(ContainerBuilder builder)
        {
            builder.RegisterType<TipDomain>().As<ITipDomain>() .WithParameter("dbDao", new DbTipDao());
        }
    }
}
