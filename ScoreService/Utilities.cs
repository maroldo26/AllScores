using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ScoreService
{
    public class Utilities
    {
        public static string ConvertToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}