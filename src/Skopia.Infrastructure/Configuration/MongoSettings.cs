using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Configuration
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Database { get; set; } = null!;
    }

}
