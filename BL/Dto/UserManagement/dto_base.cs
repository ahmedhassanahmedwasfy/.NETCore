using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dto
{
    public class dto_Identity
    {
        public dto_Identity()
        {
            //ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
    }
    public class dto_base : dto_Identity
    {
        public Guid? CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
