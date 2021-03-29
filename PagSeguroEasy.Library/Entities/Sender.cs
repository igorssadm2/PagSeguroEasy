

using System.Collections.Generic;

namespace PagSeguroEasy.Library.Entities
{
  public class Sender
    {
        public string name { get; set; }
        public string email { get; set; }
        public string hash { get; set; }
        public Phone phone { get; set; }
        public List<SenderDocument> documents { get; set; }

        public Sender()
        {
            this.phone = new Phone();
            this.documents = new List<SenderDocument>();
        }
    }
}
