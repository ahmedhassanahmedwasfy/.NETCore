using CORE.BL.Dto.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.Dto
{
    public class dto_User : dto_NamedBase
    {
        public dto_User()
        {
            Groups = new List<dto_Group>();
            Privilliges = new List<dto_Privillige>();
        }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAD { get; set; }
        public bool IsThirdParty { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; } 
        public dto_UserType UserType { get; set; }
        public Guid? UserTypeID { get; set; }


        #region Security
        public bool isActivated { get; set; }
        public DateTime? ActivationStartDate { get; set; }
        public DateTime? ActivationEndDate { get; set; }
        public List<dto_Group> Groups { get; set; }
        public List<dto_Privillige> Privilliges { get; set; }
        #endregion

    }
}
