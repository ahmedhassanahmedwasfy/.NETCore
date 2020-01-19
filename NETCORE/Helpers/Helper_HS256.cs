using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target_NETCORE.Models.API.Account;

namespace Target_NETCORE.Helpers
{
    public class Helper_HS256
    {
        public static UserTokenModel Decode(string token)
        {
            byte[] b_secretKey = ASCIIEncoding.UTF8.GetBytes("secret");

            string json = Jose.JWT.Decode(token, b_secretKey);
            UserTokenModel tokenModel = JsonConvert.DeserializeObject<UserTokenModel>(json);
            return tokenModel;
        }
    }
}
