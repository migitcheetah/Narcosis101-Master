using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Narcosis101.DAL
{
    public class ItemConfiguration : DbConfiguration
    {
        public ItemConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}