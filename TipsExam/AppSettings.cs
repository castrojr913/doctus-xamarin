using System;
using TipsExam.Dependency;

namespace TipsExam
{
    /// <summary>
    /// App settings.
    /// </summary>
    public static class AppSettings
    {

        public const string Database = "prueba.db";
        public const string DefaultDateFormat = "MMMM dd yyyy";
        public const string DatabaseDateFormat = "yyyy-MM-dd";

        public static readonly Autofac.IContainer DependencyInjector;

        static AppSettings()
        {
        
            // IoC (Dependency Inversion)
            var appModule = new AppModule();
            DependencyInjector = appModule.GetIoC();

        }

    }
}
