//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.common.Helpers
{
    public class JsonHelpers<T> where T : class
    {
        public static T GetJsonFile(string Path)
        {
            string content = File.ReadAllText(Path);
            T obj =  JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
    }
}
