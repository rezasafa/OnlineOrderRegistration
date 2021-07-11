using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using pwaSepehr.MyModels;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace pwaSepehr.Business
{
    public class ENCODES
    {
        public string ConvetToUTF8(string SVAL)
        {
            byte[] bytes = Encoding.Default.GetBytes(SVAL);
            return Encoding.UTF8.GetString(bytes);
        }

        public string MyDictionaryToJson(Dictionary<int, List<int>> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }
    }
}
