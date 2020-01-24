using CORE.DAL.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.Dto
{
   public class dto_GridSettings : dto_base
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid UserID { get; set; }
        public dto_User User { get; set; }
    }
}
