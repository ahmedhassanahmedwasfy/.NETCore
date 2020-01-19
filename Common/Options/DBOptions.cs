using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.infrastructure
{
    public class DBOptions
    {
        public string ConnectionString { get; set; }
        public string Stage { get; set; }
        public string Production { get; set; }
        public string Testing { get; set; }
    }
}
