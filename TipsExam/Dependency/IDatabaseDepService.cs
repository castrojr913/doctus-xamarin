using System;
namespace TipsExam.Dependency
{
    /// <summary>
    /// Database dependency service.
    /// </summary>
    public interface IDatabaseDepService
    {

        /// <summary>
        /// Gets the database path.
        /// </summary>
        /// <returns>The database path.</returns>
        string GetDatabasePath();

    }
}
