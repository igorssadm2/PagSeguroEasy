

using msShop.TagHelpers;

namespace msShop.Models
{
    /// <summary>
    /// Represents a senderDocument
    /// </summary>
    public class document
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
    	public document(){

    	}

        /// <summary>
        /// Initializes a new instance of the SenderDocumet class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
    	public document(string type, string value)
        {
            this.type = type;
            this.value = PagSeguroUtil.GetOnlyNumbers(value);
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
