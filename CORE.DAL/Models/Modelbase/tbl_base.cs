using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL.Models.UserManagement
{
    public class tbl_Identity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        //[Key()]
        public virtual Guid ID { get; set; }
    }
    public class tbl_base : tbl_Identity
    {
        public tbl_base()
        {
            //this.ID = Guid.NewGuid();
        }
        
        public Guid? CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDeleted { get; set; }

    }
    /*
      public class tbl_Identity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()] 
        [Key()]
        public int ID { get; set; }
    }
    public class tbl_base : tbl_Identity
    {
        public int CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }
    }
     */
}
