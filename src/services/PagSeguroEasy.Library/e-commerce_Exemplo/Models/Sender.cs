
using System;
using System.Collections.Generic;


namespace msShop.Models
{
    /// <summary>
    /// Represents the party on the transaction that is sending the money
    /// </summary>
    public class sender
    {
        public string name { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public Phone phone { get; set; }
        public List<document> documents { get; set; }

        public sender()
        {
            this.phone = new Phone();
            this.documents = new List<document>();
        }
    }
}
