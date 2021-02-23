using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TomBot.Database
{
    public partial class TomBotEntities : DbContext
    {
        public virtual DbSet<EightBallAnswer> EightBallAnswer { get; set; }
        public virtual DbSet<RememberThis> RememberThis { get; set; }
        public virtual DbSet<TomQuotes> TomQuotes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TomBot.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }        
    }
}