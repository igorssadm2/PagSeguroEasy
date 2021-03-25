

using System.Collections.Generic;

namespace PagSeguroEasy.Library.Entities
{
   public class Holder
    {     
        public Holder()
        {
            this.documents = new List<SenderDocument>();
            this.phone = new Phone();
        }
        public string name { get; set; }

        public List<SenderDocument> documents;
        public string birthDate { get; set; }

        public Phone phone { get; set; }
    }
}

