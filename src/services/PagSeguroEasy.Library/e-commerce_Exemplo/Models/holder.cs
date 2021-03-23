using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class holder
    {
        public holder()
        {
            this.documents = new List<document>();
            this.phone = new Phone();
        }
        public string name { get; set; }
       
        public List<document> documents;
        public string birthDate { get; set; }

        public Phone phone { get; set; }
    }
}
