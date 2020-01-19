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
    public class tbl_Privillige : tbl_NamedBase
    {
        public tbl_Privillige()
        {
            tbl_Privilligetbl_Group = new List<tbl_Privilligetbl_Group>();
            tbl_Privilligetbl_User = new List<tbl_Privilligetbl_User>();
        }
         
        public string Key { get; set; }


        //public List<tbl_Group> Groups { get; set; }


        //public List<tbl_User> Users { get; set; }
        public List<tbl_Privilligetbl_Group> tbl_Privilligetbl_Group { get; set; }
        public List<tbl_Privilligetbl_User> tbl_Privilligetbl_User { get; set; }

    }
}
