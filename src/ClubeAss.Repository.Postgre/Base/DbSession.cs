using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Data;

namespace ClubeAss.Repository.Postegre.Base
{
    public sealed class DbSession : IDisposable
    {
        
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration, ILogger<DbSession> _logger)
        {
            try
            {
                Connection = new NpgsqlConnection(configuration.GetConnectionString("PGConexao"));
                Connection.Open();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro para conectar no banco de dados");
                throw;
            }
           
        }

        public void Dispose() => Connection?.Dispose();
    }
}