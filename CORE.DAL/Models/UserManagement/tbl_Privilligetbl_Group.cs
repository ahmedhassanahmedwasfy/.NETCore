using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.UserManagement
{
   public class tbl_Privilligetbl_Group  //: tbl_Identity
    {
        [ForeignKey("tbl_Privillige_ID")]
        public tbl_Privillige Privillige { get; set; }
        [ForeignKey("tbl_Group_ID")] 
        public tbl_Group  Group { get; set; }
        public Guid tbl_Privillige_ID { get; set; }
        public Guid tbl_Group_ID { get; set; }
    }
}
