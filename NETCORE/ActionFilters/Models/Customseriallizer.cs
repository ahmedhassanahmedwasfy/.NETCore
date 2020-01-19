using Jose;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Target_NETCORE.ActionFilters.Models
{
    public class Customseriallizer : IJsonMapper
    {
        public T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object obj)
        {
            //try
            {
                string json = JsonConvert.SerializeObject(obj, Formatting.None,
    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return json;
            }
            //catch (Exception ex)
            //{
            //    return string.Empty;
            //}

        }
    }
}