using LearningProject.Models;
using LearningProject.Objects;
using Microsoft.Extensions.Configuration;
using System;

namespace LearningProject.Helpers
{
    public class DbConnectionHandler : IDbConnectionHandler
    {
        private readonly IConfiguration _configuration;

        public DbConnectionHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string DbConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("DbConnection");
            }
        }

        public bool IsInitReq()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public bool IsDbOnline()
        {
            throw new NotImplementedException();
        }

        public bool IsMigrationRequired()
        {
            throw new NotImplementedException();
        }

        public void Save(string serverName, string databaseName, string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateOrUpdateDb(out string error)
        {
            throw new NotImplementedException();
        }

        public DbConnectionModel Model { get; }
    }
}
