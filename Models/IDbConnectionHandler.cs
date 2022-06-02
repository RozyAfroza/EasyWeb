using LearningProject.Objects;

namespace LearningProject.Models
{
    public interface IDbConnectionHandler
    {
        string DbConnectionString { get; }

        bool IsInitReq();
        void Init();
        bool IsDbOnline();
        bool IsMigrationRequired();
        void Save(string serverName, string databaseName, string username, string password);
        bool CreateOrUpdateDb(out string error);

        DbConnectionModel Model { get; }
    }
}
