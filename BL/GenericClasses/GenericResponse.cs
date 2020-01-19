using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GenericClasses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object data { get; set; }


        public void FillSuccess()
        {
            Message = Common.Resources.General.success;
            Success = true;
        }
        public void FillError()
        {
            Message = Common.Resources.General.failed;
            Success = false;
        }
        public void FillError(string err)
        {
            Message = err;
            Success = false;
        }
        public void FillError(Exception ex)
        {
            Message = ex.Message;
            Success = false;
        }
    }
}
