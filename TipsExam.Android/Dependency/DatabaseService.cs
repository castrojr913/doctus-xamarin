using System;
using System.IO;
using TipsExam.Dependency;

[assembly: Xamarin.Forms.Dependency(typeof(TipsExam.Droid.Dependency.DatabaseService))]
namespace TipsExam.Droid.Dependency
{
    ///<inheritdoc/>
    public class DatabaseService : IDatabaseDepService
    {
        ///<inheritdoc/>
        public string GetDatabasePath() => Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.Personal), AppSettings.Database);
    }
}
