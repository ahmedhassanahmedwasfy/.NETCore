using DAL.Models.Modelbase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.UserManagement
{
    public class tbl_Group : tbl_NamedBase
    {
        public tbl_Group()
        {
            tbl_Grouptbl_User = new List<tbl_Grouptbl_User>();
            tbl_Privilligetbl_Group = new List<tbl_Privilligetbl_Group>();
        }
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public override int ID { get; set; }


        //public List<tbl_Privillige> Privilliges { get; set; } 
        //public List<tbl_User> Users { get; set; }
        public List<tbl_Grouptbl_User> tbl_Grouptbl_User { get; set; }
        public List<tbl_Privilligetbl_Group> tbl_Privilligetbl_Group { get; set; }


    }
}
