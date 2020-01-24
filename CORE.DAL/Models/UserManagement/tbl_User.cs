using CORE.DAL.Models.Modelbase; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.UserManagement
{
   public class tbl_User: tbl_NamedBase
    {
        public tbl_User()
        {
            tbl_Grouptbl_User = new List<tbl_Grouptbl_User>();
            tbl_Privilligetbl_User = new List<tbl_Privilligetbl_User>();
        }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAD { get; set; }
        public bool IsThirdParty { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        [ForeignKey("UserTypeID")]
        public tbl_UserType UserType { get; set; }
        public Guid? UserTypeID { get; set; }

        #region Security
        public bool isActivated { get; set; }
        public DateTime? ActivationStartDate { get; set; }
        public DateTime? ActivationEndDate { get; set; }

        //public List<tbl_Group> Groups { get; set; }


        //public List<tbl_Privillige> Privilliges { get; set; }
        public List<tbl_Grouptbl_User> tbl_Grouptbl_User { get; set; }
        public List<tbl_Privilligetbl_User> tbl_Privilligetbl_User { get; set; }

        #endregion
    }
}
