using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.UserManagement
{
    public class tbl_Privilligetbl_User   //: tbl_Identity
    {
        [ForeignKey("tbl_Privillige_ID")]
        public tbl_Privillige Privillige { get; set; }
        [ForeignKey("tbl_User_ID")]
        public tbl_User User { get; set; }
        public Guid tbl_Privillige_ID { get; set; }
        public Guid tbl_User_ID { get; set; }
    }
}
