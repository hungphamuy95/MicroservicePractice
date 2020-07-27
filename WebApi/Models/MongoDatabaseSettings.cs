using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MongoDatabaseSettings
    {
        public string ConnectionsString { get; set; }
        public string DatabaseName { get; set; }
    }
}
