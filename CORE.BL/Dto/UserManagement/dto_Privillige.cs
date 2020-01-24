using CORE.DAL.Models.UserManagement;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CORE.BL.Dto
{
    public class dto_Privillige : dto_base
    {
        public dto_Privillige()
        {
            Groups = new List<dto_Group>();
            Users = new List<dto_User>(); 
        }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Key { get; set; }
        public List<dto_Group> Groups { get; set; }  
        public List<dto_User> Users { get; set; }
    }
}