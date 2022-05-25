using entity_framework;
using Microsoft.EntityFrameworkCore;

namespace entities.Factory
{
    // Factory Method
    public interface IToyStoreContextCreator
    {
        ToyStoreDataContext CreateContext();
    }

    public class ToyStoreDbContextCreator : IToyStoreContextCreator
    {
        private readonly string _connectionString;
        public ToyStoreDbContextCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ToyStoreDataContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder().UseSqlServer(_connectionString);
            return new ToyStoreDataContext(builder.Options);
        }

        #region Required code for another migration
        //public ToyStoreDbContextCreator()
        //{

        //}
        // implementation of IDesignTimeDbContextFactory<ToyStoreDataContext>
        //public ToyStoreDataContext CreateDbContext(string[] args)
        //{
        //    return CreateContext();
        //} 
        #endregion
    }
}
