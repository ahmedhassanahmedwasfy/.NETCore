namespace CORE.DAL.Models
{
    using CORE.DAL.Models.UserManagement;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using Microsoft.EntityFrameworkCore.Spatial;

    
    public partial class tbl_Setting : tbl_base
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override Guid  ID { get; set; }
        //[StringLength(50)]
        //[Index("KeyIndex", IsUnique = true)]
        public string Conf_Key { get; set; }  
        public string Conf_Value { get; set; }
    }
}
