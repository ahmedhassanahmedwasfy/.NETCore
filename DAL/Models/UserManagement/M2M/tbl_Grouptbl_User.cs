using DAL.Models.Modelbase;
using DAL.SiraContext;
using DAL.SiraContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.UserManagement
{
    [Table("tbl_Grouptbl_User")]
   public class tbl_Grouptbl_User  : tbl_base
    {
        public tbl_Group Group { get; set; }
        public tbl_User User { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
    }

 
}
