 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dto
{
    public class dtoHelper
    {
        public void FillBase(dto_base model)
        {
            if (model.CreateDate == DateTime.MinValue || model.CreateDate == null)
            {
                model.CreateDate = DateTime.Now;
            }
            //if (model.ModifyDate == DateTime.MinValue || model.ModifyDate == null)
            {
                model.ModifyDate = DateTime.Now;
            }
            if (model.CreateUserID == null)
            {
                model.CreateUserID = null;
            }
            //if (model.ModifyUserID == 0)
            {
                model.ModifyUserID = null;
            }

        }
    }
}
