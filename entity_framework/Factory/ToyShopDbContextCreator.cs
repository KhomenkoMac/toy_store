using entity_framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace entity_framework.Factory
{
    // Factory Method
    public interface IToyStoreContextCreator
    {
        ToyStoreDataContext CreateContext();
    }

    public class ToyStoreDbContextCreator: IToyStoreContextCreator, IDesignTimeDbContextFactory<ToyStoreDataContext>
    {
        private readonly string _connectionString;
        public ToyStoreDbContextCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ToyStoreDataContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder().UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=toystore_db;Integrated Security=True;",
                o=> o.MigrationsAssembly("entity_framework"));
            return new ToyStoreDataContext(builder.Options);
        }

        #region Required code for another migration
        public ToyStoreDbContextCreator()
        {

        }
        // implementation of IDesignTimeDbContextFactory<ToyStoreDataContext>
        public ToyStoreDataContext CreateDbContext(string[] args)
        {
            return CreateContext();
        } 
        #endregion
    }
}
