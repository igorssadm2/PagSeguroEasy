using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class Errors
    {
        public string erro { get; set; }
    }
    [JsonObject("Errors")]
    public class Root
    {
        public Errors errors { get; set; }
        public bool error { get; set; }
    }
}
