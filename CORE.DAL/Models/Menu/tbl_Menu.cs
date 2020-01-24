using CORE.DAL.Models.Modelbase;
using CORE.DAL.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.Menu
{
    public class tbl_Menu : tbl_NamedBase
    {

        public tbl_Menu()
        {
            Children = new List<tbl_Menu>();
        }
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public override int ID { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public bool isPrivate { get; set; }
        public Guid? ParentID { get; set; }
        [ForeignKey("PrivilligeID")] 
        public tbl_Privillige Privillige { get; set; }

        public Guid? PrivilligeID { get; set; }
        [ForeignKey("ParentID")] 
        public List<tbl_Menu> Children { get; set; }
    }
}
