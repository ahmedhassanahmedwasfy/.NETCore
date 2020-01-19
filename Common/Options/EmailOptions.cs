using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Options
{
    public class EmailOptions
    {
        public string smtpHost { get; set; }
        public string EnableSsl { get; set; }
        public string port { get; set; }
        public string From { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
      
    }
}
