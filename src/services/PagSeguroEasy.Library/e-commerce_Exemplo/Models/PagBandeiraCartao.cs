using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Models
{
    public class PagBandeiraCartao
    {
        public Bin bin { get; set; }

        public class Bin
        {
            public object length { get; set; }
            public Country country { get; set; }
            public Brand brand { get; set; }
            public int bin { get; set; }
            public int cvvSize { get; set; }
            public string expirable { get; set; }
            public string validationAlgorithm { get; set; }
            public object bank { get; set; }
            public object cardLevel { get; set; }
            public string statusMessage { get; set; }
            public object reasonMessage { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public int id { get; set; }
            public string isoCode { get; set; }
            public string isoCodeThreeDigits { get; set; }
        }

        public class Brand
        {
            public string name { get; set; }
        }

    }
}
