

using PagSeguroEasy.Library.Utils;

namespace PagSeguroEasy.Library.Entities
{
   public class SenderDocument
    {
        /// <summary>
        /// Sender document type
        /// </summary>
        public string type
        {
            get;
            set;
        }

        /// <summary>
        /// Sender document value
        /// </summary>
        public string value
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
    	public SenderDocument()
        {

        }

        /// <summary>
        /// Initializes a new instance of the SenderDocumet class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
    	public SenderDocument(string type, string value)
        {
            this.type = type;
            this.value = PagSeguroUtils.GetOnlyNumbers(value);
        }

        /// <summary>
        /// Gets toString class
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return "SenderDocument [type=" + this.type + ", value=" + this.value + "]";
        }
    }
}
