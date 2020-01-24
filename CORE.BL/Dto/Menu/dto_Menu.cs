using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.Dto.Menu
{
    public class dto_Menu : dto_NamedBase
    {
        public dto_Menu()
        {
            children = new List<dto_Menu>();
        }
 
        public string icon { get; set; }
        public string link { get; set; }
        public bool isPrivate { get; set; }
        public Guid? ParentID { get; set; }

        public dto_Privillige Privillige { get; set; }
        public List<dto_Menu> children { get; set; }
    }
}
