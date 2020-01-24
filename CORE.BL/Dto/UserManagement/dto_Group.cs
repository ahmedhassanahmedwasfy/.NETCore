using System.Collections.Generic;

namespace CORE.BL.Dto
{
    public class dto_Group :dto_base
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public List<dto_Privillige> Privilliges { get; set; }
        public List<dto_User> Users { get; set; }
    }
}