using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dto
{

    public class dto_NamedBase : dto_base
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }
}
