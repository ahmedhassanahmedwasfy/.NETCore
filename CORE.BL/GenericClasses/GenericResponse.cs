using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.BL.GenericClasses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object data { get; set; }


        public void FillSuccess()
        {
            Message = "success";
            Success = true;
        }
        public void FillError()
        {
            Message = "failed";
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
