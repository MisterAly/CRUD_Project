using Microsoft.EntityFrameworkCore;


namespace CRUD_project.Infra.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) 
        { 
        }

        public MainContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                var sqlitePath = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), @"CRUD-project\CRUD-project.Web\DevsdbSqlite");
                optionsBuilder
                    .UseSqlite($"Data Source={sqlitePath}");
            }
        }
    }
}
