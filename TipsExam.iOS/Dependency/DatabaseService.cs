using System;
using System.IO;
using TipsExam.Dependency;

[assembly: Xamarin.Forms.Dependency(typeof(TipsExam.iOS.Dependency.DatabaseService))]
namespace TipsExam.iOS.Dependency
{
    ///<inheritdoc/>
    public class DatabaseService : IDatabaseDepService
    {
        ///<inheritdoc/>
        public string GetDatabasePath() => Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", AppSettings.Database);

    }
}
