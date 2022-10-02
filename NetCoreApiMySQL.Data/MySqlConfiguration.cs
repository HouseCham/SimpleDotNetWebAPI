using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApiMySQL.Data
{
    public class MySqlConfiguration
    {
        public string ConnectionString { get; set; }

        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
